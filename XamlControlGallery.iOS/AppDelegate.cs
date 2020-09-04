using Avalonia;
using Avalonia.iOS;
using Avalonia.ReactiveUI;
using Foundation;
using XamlControlsGallery;

namespace XamlControlGallery.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : AvaloniaAppDelegate<App>
    {
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            builder.UseReactiveUI();

            return base.CustomizeAppBuilder(builder);
        }
    }
}

