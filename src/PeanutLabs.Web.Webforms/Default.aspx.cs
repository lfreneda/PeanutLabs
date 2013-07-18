using System;
using PeanutLabs.Configuration;

namespace PeanutLabs.Web.Webforms
{
    public partial class _Default : System.Web.UI.Page
    {
        public string IframeUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsAppSettings());
            IframeUrl = peanutLabsUrl.IframeUrl(publisherUserId: 1508);
        }
    }
}
