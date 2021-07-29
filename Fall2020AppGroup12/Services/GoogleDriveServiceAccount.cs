//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Security.Cryptography.X509Certificates;

//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Plus.v1;
//using Google.Apis.Plus.v1.Data;
//using Google.Apis.Services;
//using System.IO;
//using GSF.IO;
//using System.Reflection;

//namespace Fall2020AppGroup12.GoogleAuth
//{
//    /// <summary>
//    /// This sample demonstrates the simplest use case for a Service Account service.
//    /// The certificate needs to be downloaded from the Google API Console
//    /// <see cref="https://console.developers.google.com/">
//    ///   "Create another client ID..." -> "Service Account" -> Download the certificate,
//    ///   rename it as "key.p12" and add it to the project. Don't forget to change the Build action
//    ///   to "Content" and the Copy to Output Directory to "Copy if newer".
//    /// </summary>
//    public class GoogleDriveServiceAccount
//    {
//        // A known public activity.
//        private static String ACTIVITY_ID = "z12gtjhq3qn2xxl2o224exwiqruvtda0i";

//        public static void StartGoogleDriveService()
//        {
//            Console.WriteLine("Plus API - Service Account");
//            Console.WriteLine("==========================");

//            String serviceAccountEmail = "group-12-service-account@authentic-ether-310303.iam.gserviceaccount.com";
        

//            //var certificate = new X509Certificate2(File.ReadAllBytes(@"~\Services\key.p12"), "notasecret", X509KeyStorageFlags.Exportable);
//            var certificate = new X509Certificate2(File.ReadAllBytes(@"C:\Users\adams\source\repos\Fall2020SolutionGroup12\Fall2020SolutionGroup12\Fall2020AppGroup12\Services\key.p12"), "notasecret", X509KeyStorageFlags.Exportable);
//            ServiceAccountCredential credential = new ServiceAccountCredential(
//               new ServiceAccountCredential.Initializer(serviceAccountEmail)
//               {
//                   Scopes = new[] { PlusService.Scope.PlusMe }
//               }.FromCertificate(certificate));

//            // Create the service.
//            var service = new GoogleDriveServiceAccount(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = "Plus API Sample",
//            });


//            GoogleDriveServiceAccount gdService = new GoogleDriveServiceAccount();

//            gdService = service.Activities;

//            Activity activity = service.Activities.Get(ACTIVITY_ID).Execute();



//            foreach(PropertyInfo x in activity.GetType().GetProperties())
//            {
//                if (x != null)
//                    Console.WriteLine(x);
//            }

//            //Console.WriteLine(activity.Url);


//            //Console.WriteLine("  Activity: " + activity.Object__.Content);
//            //Console.WriteLine("  Video: " + activity.Object__.Attachments[0].Url);

//            //Console.WriteLine("Press any key to continue...");
//            //Console.ReadKey();
//        }
//    }
//}
