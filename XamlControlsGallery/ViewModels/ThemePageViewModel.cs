using System;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Media;
using ReactiveUI;
using XamlControlsGallery.Helpers;

namespace XamlControlsGallery.ViewModels
{
    public class ThemePageViewModel : ViewModelBase
    {
        public ThemePageViewModel()
        {
            OnClickCommand = ReactiveCommand.Create(ThemeHelper.ToggleTheme);
        }

        public ReactiveCommand<Unit, Unit> OnClickCommand { get; }
    }
}
