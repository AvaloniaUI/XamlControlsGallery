using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace XamlControlsGallery.Views
{
    public class MainWindow : FluentWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var closeButton = this.FindControl<Panel>("PART_CloseButton");
            var restoreButton = this.FindControl<Panel>("PART_RestoreButton");
            var minimiseButton = this.FindControl<Panel>("PART_MinimiseButton");
            var fullScreenButton = this.FindControl<Panel>("PART_FullScreenButton");

            closeButton.PointerPressed += (sender, e) => Close();
            restoreButton.PointerPressed += (sender, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            minimiseButton.PointerPressed += (sender, e) => WindowState = WindowState.Minimized;
            fullScreenButton.PointerPressed += (sender, e) => WindowState = WindowState == WindowState.FullScreen ? WindowState.Normal : WindowState.FullScreen;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
