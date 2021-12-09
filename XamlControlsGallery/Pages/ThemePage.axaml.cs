using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.OpenGL.Egl;
using XamlControlsGallery.Helpers;
using XamlControlsGallery.ViewModels;

namespace XamlControlsGallery.Pages
{
    public class ThemePage : UserControl
    {
        public ThemePage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
            DataContext = new ThemePageViewModel();
        }
    }
}
