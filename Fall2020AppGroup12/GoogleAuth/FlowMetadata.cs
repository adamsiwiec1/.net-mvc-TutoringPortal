using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;

namespace Fall2020AppGroup12.GoogleAuth
{
    public abstract class FlowMetadata
    {
        protected FlowMetadata() { return; }

        //     Gets the authorization code flow.
        public abstract IAuthorizationCodeFlow Flow { get; }

        //     Gets the authorization application's call back. That relative URL will handle
        //     the authorization code response.
        public virtual string AuthCallback { get; }

        public abstract string GetUserId(Controller controller);
    }
}