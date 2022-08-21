using EDUFA1.DataModel;
using System;
using System.Collections.Generic;
using System.Web;

namespace EDUFA1.Models
{
    public class UploadedMaterialsModelView
    {
        public int Sl_No { get; set; }
        public string UploadedBy { get; set; }
        public string File_Subject { get; set; }
        public string FilePath { get; set; }
        public string Remark { get; set; }
        public bool isApproved { get; set; }
        public bool isDeleted { get; set; }
        public HttpPostedFileBase FileName { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }

    }
    public class UploadedFileWithCredentials
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public List<UploadedFile> files{get; set;}
    }
}
