using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using XamlControlsGallery.ViewModels;

namespace XamlControlsGallery.Pages
{
    public class LayoutPageViewModel : ViewModelBase
    {
        public class ItemViewModel
        {
            public ItemViewModel(int i, Color color)
            {
                Text = i.ToString();
                Color = color;
            }

            public string Text { get; }

            public Color Color { get; }
        }

        public LayoutPageViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();

            var availableColors = new []
            {
                Colors.Red, Colors.Blue, Colors.CornflowerBlue, Colors.Gray, Colors.Magenta, Colors.Brown, Colors.Orange, Colors.Crimson
            };

            var random = new Random(0);

            for (int i = 0; i < 10000; i++)
            {
                var color = availableColors[random.Next(0, availableColors.Length)];

                var item = new ItemViewModel(i, color);

                Items.Add(item);
            }
        }

        public ObservableCollection<ItemViewModel> Items { get; }
    }

    public class LayoutPage : UserControl
    {
        public LayoutPage()
        {
            this.InitializeComponent();

            DataContext = new LayoutPageViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
