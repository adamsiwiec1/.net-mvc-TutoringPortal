//using Fall2020AppGroup12.GoogleAuth;
//using Google.Apis.Drive.v3;
//using Google.Apis.Services;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;


//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Auth.OAuth2.Flows;
//using Google.Apis.Util.Store;
//using Google.Apis.Auth.OAuth2.Mvc;
//using Fall2020AppGroup12.Models.GoogleModels;

//namespace Fall2020AppGroup12.Controllers
//{
//    public class GoogleDriveController : Microsoft.AspNetCore.Mvc.Controller
//    {

//        public IDataStore iDataStore;

//        public GoogleDriveController(IDataStore dataStore)
//        {
//            iDataStore = dataStore;
//        }




//        public async Task<Microsoft.AspNetCore.Mvc.ActionResult> IndexAsync(CancellationToken cancellationToken)
//        {


//            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
//                AuthorizeAsync(cancellationToken);

//            if (result.Credential != null)
//            {
//                var service = new DriveService(new BaseClientService.Initializer
//                {
//                    HttpClientInitializer = result.Credential,
//                    ApplicationName = "ASP.NET MVC Sample"
//                });

//                // YOUR CODE SHOULD BE HERE..
//                // SAMPLE CODE:
//                var list = await service.Files.List().ExecuteAsync();
//                ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();
//                return View();
//            }
//            else
//            {
//                return new Microsoft.AspNetCore.Mvc.RedirectResult(result.RedirectUri);
//            }
//        }






















        //public async Task<System.Web.Mvc.ActionResult> GoogleDriveIndex(CancellationToken cancellationToken)
        //{

        //    GoogleDriveController gc = new GoogleDriveController(iDataStore);

        //    var x = gc.iDataStore.;

        //    var key = gc.iDataStore.ToString();

        //    gc.iDataStore.GetAsync(key);

        //    var result = await new gc(this, new AppAuthFlowMetaData()).
        //        AuthorizeAsync(cancellationToken);

        //    if (result.Credential != null)
        //    {
        //        var service = new DriveService(new BaseClientService.Initializer
        //        {
        //            HttpClientInitializer = result.Credential,
        //            ApplicationName = "ASP.NET MVC Sample"
        //        });

        //        // YOUR CODE SHOULD BE HERE..
        //        // SAMPLE CODE:
        //        var list = await service.Files.List().ExecuteAsync();
        //        string fileCount = "FILE COUNT IS: " + list.Files.Count();
        //        return View();
        //    }
        //    else
        //    {
        //        return new System.Web.Mvc.RedirectResult(result.RedirectUri);
        //    }
        //}


        //[Authorize]
        //public async Task<System.Web.Mvc.ActionResult> DriveAsync(CancellationToken cancellationToken)
        //{
        //    ViewBag.Message = "Your drive page.";

        //    var result = await new Fall2020AppGroup12.GoogleAuth.AuthorizationCodeMvcApp(this, new AppAuthFlowMetaData()).
        //            AuthorizeAsync(cancellationToken);

        //    if (result.Credential == null)
        //        return new System.Web.Mvc.RedirectResult(result.RedirectUri);

        //    var driveService = new DriveService(new BaseClientService.Initializer
        //    {
        //        HttpClientInitializer = result.Credential,
        //        ApplicationName = "ASP.NET Google APIs MVC Sample"
        //    });

        //    var listReq = driveService.Files.List();
        //    listReq.Fields = "items/title,items/id,items/createdDate,items/downloadUrl,items/exportLinks";
        //    var list = await listReq.ExecuteAsync();
        //    var items =
        //        (from file in list.Files
        //         select new GoogleDriveFile
        //         {
        //             Title = file.Name,
        //             Id = file.Id,
        //             CreatedDate = file.CreatedTime,
        //             DownloadUrl = file.WebViewLink ??
        //                                        (file.ExportLinks != null ? file.ExportLinks["application/pdf"] : null),
        //         }).OrderBy(f => f.Title).ToList();
        //    return View(items);
        //}


//    }
//}
