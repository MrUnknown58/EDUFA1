using EDUFA1.DataModel;
using EDUFA1.Models;

using ezy.school.models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ezy.school.models.Mapper
{
    public static class UploadedFilesMapping
    {
        public static UploadedFile Map(UploadedMaterialsModelView model)
        {
            if (model == null)
                return null;
            var obj = new UploadedFile()
            {
                UploadedBy = model.UploadedBy,
                isDeleted=model.isDeleted,
                FilePath=model.FilePath,
                File_Subject=model.File_Subject,
                isApproved=model.isApproved,
                Remark=model.Remark,
            };
            return obj;
        }
        public static UploadedFile Map(UploadedFilesView model)
        {
            if (model == null)
                return null;
            var obj = new UploadedFile()
            {
                UploadedBy = model.UploadedBy,
                isDeleted = model.isDeleted,
                FilePath = model.FilePath,
                File_Subject = model.File_Subject,
                isApproved = model.isApproved,
                Remark = model.Remark,
            };

            return obj;
        }
    }
}
