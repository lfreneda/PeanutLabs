using System;
using PeanutLabs.Configuration;

namespace PeanutLabs.Web.Webforms
{
    public partial class Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var callback = new PeanutLabsCallbackSample(new PeanutLabsAppSettings());
            callback.Process(new RequestCallback("customParameter", "customParameter2"));
        }
    }
}