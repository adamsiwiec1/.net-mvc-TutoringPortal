using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.GoogleModels
{
    public class GoogleDriveFile
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DownloadUrl { get; set; }

    }
}
