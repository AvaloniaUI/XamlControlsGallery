using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Diagnostics;
using ABI.System.Windows.Input;
using ReactiveUI;
using System.Reactive;

namespace XamlControlsGallery.Views
{    

    public class MainWindow : FluentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();    
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            CompositionHost.Instance.Initialize(PlatformImpl.Handle.Handle);
        }        
    }
}
