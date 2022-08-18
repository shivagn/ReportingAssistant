using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reporting.DomainModels;

namespace ReportingAssistant.extentions
{
    public static class AddFile
    {
        public static string File(this Project project, HttpPostedFileBase file)
        {
            var imageBytes = new Byte[file.ContentLength - 1];
            file.InputStream.Read(imageBytes, 0, file.ContentLength - 1);
            var base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return base64string;
        }
    }
}