using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBankApp.Services
{
    public interface IFileHelper
    {
        string GetDownloadFilePath(string folderName, string fileName);
    }
}
