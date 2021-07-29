//using Fall2020AppGroup12.Services;
//using Google.Apis.Auth.OAuth2.Web;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace Fall2020AppGroup12.GoogleAuth
//{
//    public class AuthorizationCodeMvcApp : Fall2020AppGroup12.GoogleAuth.AuthorizationCodeWebApp
//    {
//        //
//        // Summary:
//        //     Constructs a new authorization code MVC app using the given controller and flow
//        //     data.
//        public AuthorizationCodeMvcApp(Controller controller, FlowMetadata flowData) { return; }
//        //
//        // Summary:
//        //     Gets the controller which is the owner of this authorization code MVC app instance.
//        public Controller Controller { get; }
//        //
//        // Summary:
//        //     Gets the Google.Apis.Auth.OAuth2.Mvc.FlowMetadata object.
//        public FlowMetadata FlowData { get; }

//        //
//        // Summary:
//        //     Asynchronously authorizes the installed application to access user's protected
//        //     data. It gets the user identifier by calling to Google.Apis.Auth.OAuth2.Mvc.FlowMetadata.GetUserId(System.Web.Mvc.Controller)
//        //     and then calls to Google.Apis.Auth.OAuth2.Web.AuthorizationCodeWebApp.AuthorizeAsync(System.String,System.Threading.CancellationToken).
//        //
//        // Parameters:
//        //   taskCancellationToken:
//        //     Cancellation token to cancel an operation
//        //
//        // Returns:
//        //     Auth result object which contains the user's credential or redirect URI for the
//        //     authorization server
//        public Task<AuthResult> AuthorizeAsync(CancellationToken taskCancellationToken)
//        {
//            return AuthResult>();
//        }
//    }
//}
