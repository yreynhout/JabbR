using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JabbR.ContentProviders.Core;

namespace JabbR.ContentProviders
{
    public class TwitPicContentProvider : CollapsibleContentProvider
    {
        private static readonly Regex _twitPicUrlRegex = new Regex(@"^http://(www\.)?twitpic\.com/(?<Id>\w+)", RegexOptions.IgnoreCase);

        private const string TwitPicFormatString = @"<a href=""http://twitpic.com/{0}""> <img src=""http://twitpic.com/show/large/{0}""></a>";

        protected override Task<ContentProviderResult> GetCollapsibleContent(ContentProviderHttpRequest request)
        {
            var match = _twitPicUrlRegex.Match(request.RequestUri.AbsoluteUri);

            if (match.Success)
            {
                var id = match.Groups["Id"].Value;
                return TaskAsyncHelper.FromResult(new ContentProviderResult
                {
                    Content = String.Format(TwitPicFormatString, id),
                    Title = request.RequestUri.AbsoluteUri
                });
            }

            return TaskAsyncHelper.FromResult<ContentProviderResult>(null);
        }

        public override bool IsValidContent(Uri uri)
        {
            return _twitPicUrlRegex.IsMatch(uri.AbsoluteUri);
        }
    }
}