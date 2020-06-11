using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;

namespace XamlControlsGallery.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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
