using Android.App;
using Android.Runtime;
// Para abrir la galeria
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]

// Para tomar una foto
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]

// Add these properties if you would like to filter out devices that do not have cameras, or set to false to make them optional
[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]

namespace UI;


[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

