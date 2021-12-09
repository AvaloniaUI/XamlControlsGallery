using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace XamlControlsGallery.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<XamlControlsGallery.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}
