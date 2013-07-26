using System;

namespace JabbR.ContentProviders.Core
{
    public class ContentProviderHttpRequest
    {        
        public ContentProviderHttpRequest(Uri url)
        {
            RequestUri = url;
        }

        public Uri RequestUri { get; private set; }
    }
}