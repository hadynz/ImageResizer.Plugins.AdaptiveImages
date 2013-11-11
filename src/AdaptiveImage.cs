using System;
using System.Web;
using ImageResizer.Configuration;

namespace ImageResizer.Plugins.AdaptiveImages
{
    public class AdaptiveImage : IPlugin
    {
        private const string ResolutionCookieKey = "resolution";

        private const string UserAgentMobileSubstring = "mobile";

        private readonly string[] _resolutions = new[] { "1382", "992", "768", "480" };

        public IPlugin Install(Config c)
        {
            c.Pipeline.PostRewrite += Pipeline_PostRewrite;
            return this;
        }

        private void Pipeline_PostRewrite(IHttpModule sender, HttpContext context, IUrlEventArgs e)
        {
            HttpRequest httpRequest = HttpContext.Current.Request;

            // If resolution of current screen has been passed, set maxwidth 
            // parameter for ImageResizer to handle in its pipeline
            HttpCookie httpCookie = httpRequest.Cookies.Get(ResolutionCookieKey);

            if (httpCookie != null)
            {
                e.QueryString.Add("maxwidth", httpCookie.Value);
            }

            // A cookie has not been set. If current user agent is identified 
            // as a mobile device, serve the smallest image
            else if (httpRequest.UserAgent.ToLower().Contains(UserAgentMobileSubstring))
            {
                string width = _resolutions[_resolutions.Length - 1];
                e.QueryString.Add("maxwidth", width);
            }
        }

        public bool Uninstall(Config c)
        {
            c.Pipeline.PostRewrite -= Pipeline_PostRewrite;
            return true;
        }
    }
}