using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JabbR.ContentProviders.Core;

namespace JabbR.ContentProviders
{
    public class GitHubIssuesContentProvider : CollapsibleContentProvider
    {
        private static readonly Regex _githubIssuesRegex = new Regex(@"https://github.com(.*)/issues/(\d+)");

        private const string GitHubIssuesApiFormat = "https://api.github.com/repos{0}/issues/{1}?callback=addGitHubIssue";
        private const string GitHubIssuesContentFormat = "<div class='git-hub-issue git-hub-issue-{0}'></div><script src='{1}'></script>";

        protected override Task<ContentProviderResult> GetCollapsibleContent(ContentProviderHttpRequest request)
        {
            var parameters = ExtractParameters(request.RequestUri);

            return TaskAsyncHelper.FromResult(new ContentProviderResult()
            {
                Content = String.Format(GitHubIssuesContentFormat,
                                        parameters[1],
                                        String.Format(GitHubIssuesApiFormat, parameters[0], parameters[1])),
                Title = request.RequestUri.AbsoluteUri
            });
        }

        protected override Regex ParameterExtractionRegex
        {
            get
            {
                return _githubIssuesRegex;
            }
        }

        public override bool IsValidContent(Uri uri)
        {
            return ExtractParameters(uri).Count == 2;
        }
    }
}