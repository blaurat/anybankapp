using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AnyBankApp.Droid;

[Activity(Label = "AnyBankApp", Icon = "@mipmap/icon", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class SplashScreen : Activity
{
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);

        Intent intent = new Intent(this, typeof(MainActivity));
        StartActivity(intent);
        Finish();
    }
}