using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Diagnostics;
using ABI.System.Windows.Input;
using ReactiveUI;
using System.Reactive;
using System.Windows.Input;
using System.ComponentModel;
using System.Reactive.Disposables;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace XamlControlsGallery.Views
{    

    public class MainWindow : FluentWindow
    {
        private StackPanel _stackPanel;

        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();

            DataContext = this;

            _stackPanel = this.FindControl<StackPanel>("SP");
        }

        public void OnClick ()
        {
            AddRectangles();
        }

        private Rectangle CreateRectangle()
        {
            return new Rectangle
            {
                Fill = Brushes.Red,
                Height = 10,
                Width = 10
            };
        }

        private void AddRectangles ()
        {
            int veronica = 0;

            while(veronica < 10)
            {
                _stackPanel.Children.Add(CreateRectangle());
                veronica++;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            CompositionHost.Instance.Initialize(PlatformImpl.Handle.Handle);
        }        
    }
}
