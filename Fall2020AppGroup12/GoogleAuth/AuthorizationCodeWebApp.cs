//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Auth.OAuth2.Flows;
//using Google.Apis.Auth.OAuth2.Responses;
//using System.Runtime.CompilerServices;
//using System.Threading;
//using System.Threading.Tasks;
//using Google.Apis.Auth.OAuth2.Web;

//namespace Fall2020AppGroup12.GoogleAuth
//{
//    //
//    // Summary:
//    //     Thread safe OAuth 2.0 authorization code flow for a web application that persists
//    //     end-user credentials.
//    public class AuthorizationCodeWebApp
//    {
//        //
//        // Summary:
//        //     The state key. As part of making the request for authorization code we save the
//        //     original request to verify that this server create the original request.
//        public const string StateKey = "oauth_";
//        //
//        // Summary:
//        //     The length of the random number which will be added to the end of the state parameter.
//        public const int StateRandomLength = 8;

//        //
//        // Summary:
//        //     Constructs a new authorization code installed application with the given flow
//        //     and code receiver.
//        public AuthorizationCodeWebApp(IAuthorizationCodeFlow flow, string redirectUri, string state);

//        //
//        // Summary:
//        //     Gets the authorization code flow.
//        public IAuthorizationCodeFlow Flow { get; }
//        //
//        // Summary:
//        //     Gets the OAuth2 callback redirect URI.
//        public string RedirectUri { get; }
//        //
//        // Summary:
//        //     Gets the state which is used to navigate back to the page that started the OAuth
//        //     flow.
//        public string State { get; }

//        //
//        // Summary:
//        //     Asynchronously authorizes the web application to access user's protected data.
//        //
//        // Parameters:
//        //   userId:
//        //     User identifier
//        //
//        //   taskCancellationToken:
//        //     Cancellation token to cancel an operation
//        //
//        // Returns:
//        //     Auth result object which contains the user's credential or redirect URI for the
//        //     authorization server
//        [AsyncStateMachine(typeof(< AuthorizeAsync > d__13))]
//        public Task<AuthResult> AuthorizeAsync(string userId, CancellationToken taskCancellationToken);
//        //
//        // Summary:
//        //     Determines the need for retrieval of a new authorization code, based on the given
//        //     token and the authorization code flow.
//        public bool ShouldRequestAuthorizationCode(TokenResponse token);

//        //
//        // Summary:
//        //     AuthResult which contains the user's credentials if it was loaded successfully
//        //     from the store. Otherwise it contains the redirect URI for the authorization
//        //     server.
//        public class AuthResult
//        {
//            public AuthResult();

//            //
//            // Summary:
//            //     Gets or sets the user's credentials or null in case the end user needs to authorize.
//            public UserCredential Credential { get; set; }
//            //
//            // Summary:
//            //     Gets or sets the redirect URI to for the user to authorize against the authorization
//            //     server or null in case the Google.Apis.Auth.OAuth2.UserCredential was loaded
//            //     from the data store.
//            public string RedirectUri { get; set; }
//        }
//    }
//}
