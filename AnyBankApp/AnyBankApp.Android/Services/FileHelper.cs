using System.IO;
using AnyBankApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AnyBankApp.Droid.Services.FileHelper))]
namespace AnyBankApp.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetDownloadFilePath(string folderName, string fileName)
        {
            string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
            if (!Directory.Exists(Path.Combine(path, folderName)))
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }
            return Path.Combine(path, folderName, fileName);
        }
    }
}