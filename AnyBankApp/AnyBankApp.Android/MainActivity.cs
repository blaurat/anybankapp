using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using AnyBankApp.Services;
using AnyBankApp.Droid.Services;
using Android.Views;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;

namespace AnyBankApp.Droid
{
    [Activity(Label = "AnyBankApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private readonly int MY_REQUIRED_ACCES = 5463;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);            

            if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Permission.Granted) &&
                (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted))
            {
                LoadApp();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] {
                    Manifest.Permission.ReadExternalStorage,
                    Manifest.Permission.WriteExternalStorage}, MY_REQUIRED_ACCES);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            if (requestCode == MY_REQUIRED_ACCES)
            {
                bool isok = true;

                foreach (Permission permission in grantResults)
                {
                    if (permission != Permission.Granted)
                    {
                        isok = false;
                        break;
                    }
                }

                if (isok)
                    LoadApp();
                else
                    Finish();
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        private void LoadApp()
        {
            DependencyService.Register<IFileHelper, FileHelper>();
            LoadApplication(new App());
        }
    }
}