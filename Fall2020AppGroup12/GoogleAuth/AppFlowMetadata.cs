using System;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Download;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using Google.Apis.Auth.OAuth2.Mvc;

namespace Fall2020AppGroup12.GoogleAuth
{
    public class AppFlowMetadata : Fall2020AppGroup12.GoogleAuth.FlowMetadata
    {
        private IDataStore iDataStore;
        private IAuthorizationCodeFlow iAuthorizationCodeFlow;

        public AppFlowMetadata(IDataStore dataStore = null, IAuthorizationCodeFlow authorizationCodeFlow = null)
        {
            iDataStore = dataStore;
            iAuthorizationCodeFlow = authorizationCodeFlow;
        }




        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "3904297761-kl2cs1olufiknk0473eocm2b5777ae5l.apps.googleusercontent.com",
                    ClientSecret = "um0yzd0PDNSVZfYr0rpSkRkC"
                },
                Scopes = new[] { Google.Apis.Drive.v3.DriveService.Scope.Drive },
                DataStore = new FileDataStore("Drive.Api.Auth.Store")
            });

        private static readonly IAuthorizationCodeFlow flowAdam =
            new AuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "3904297761-kl2cs1olufiknk0473eocm2b5777ae5l.apps.googleusercontent.com",
                    ClientSecret = "um0yzd0PDNSVZfYr0rpSkRkC"
                },
                Scopes = new[] { Google.Apis.Drive.v3.DriveService.Scope.Drive },
                DataStore = new FileDataStore("Drive.Api.Auth.Store")
            });



        public override string GetUserId(Controller controller)
        {
            IDataStore dataStore = iAuthorizationCodeFlow.DataStore;

            return controller.User.Identity.ToString();
        }

        //public override string GetUserId(System.Web.Mvc.Controller controller)
        //{



        //    return controller.User.Identity.ToString();
        //}

        //public override IAuthorizationCodeFlow Flow
        //{
        //    get { return flow; }
        //}

        public override IAuthorizationCodeFlow Flow
        {
            get { return flowAdam; }
        }
    }
}
