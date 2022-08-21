using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ezy.school.models.Views
{
    public class UploadedFilesView
    {
        public int Sl_No { get; set; }
        public string UploadedBy { get; set; }
        public string File_Subject { get; set; }
        public string FilePath { get; set; }
        public string Remark { get; set; }
        public bool isApproved { get; set; }
        public bool isDeleted { get; set; }


    }
}
