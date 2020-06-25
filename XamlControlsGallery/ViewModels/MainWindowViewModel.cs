using System;
using System.Collections.Generic;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using ReactiveUI;

namespace XamlControlsGallery.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _isMenuItemChecked;

        public MainWindowViewModel()
        {
            ToggleMenuItemCheckedCommand = ReactiveCommand.Create(() =>
            {
                IsMenuItemChecked = !IsMenuItemChecked;
            });

            OnClick = ReactiveCommand.Create(() =>
            {
                //    var random = new Random();
                //    CompositionHost.Instance.AddElement((float)(50 + (random.NextDouble() * 150)),
                //        (float)(random.NextDouble() * 600),
                //        (float)(random.NextDouble() * 200));
                
                CompositionHost.Instance.CreateBlur(1000, 1000);
            });
        }

        public ReactiveCommand<Unit, Unit> OnClick { get; }

        public bool IsMenuItemChecked
        {
            get { return _isMenuItemChecked; }
            set { this.RaiseAndSetIfChanged(ref _isMenuItemChecked, value); }
        }

        public ReactiveCommand<Unit, Unit> ToggleMenuItemCheckedCommand { get; }

        public string Greeting => "Welcome to Avalonia!";

        public List<string> SearchItems { get; } = new List<string>
        {
            "TextBlock",
            "CheckBox",
            "ComboBox",
            "TextBox",
            "Calendar"
        };
    }
}
