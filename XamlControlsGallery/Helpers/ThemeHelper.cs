using System;
using System.Linq;
using Avalonia;
using Avalonia.Markup.Xaml.Styling;

namespace XamlControlsGallery.Helpers
{
    public static class ThemeHelper
    {
        public static ThemeMode CurrentTheme { get; private set; }

        public static void ApplyTheme(ThemeMode themeMode)
        {
            var currentTheme = Application.Current.Styles.Select(x => (StyleInclude)x).FirstOrDefault(x =>
                x.Source is { } && (x.Source.ToString().Contains("BaseDark") ||
                                    x.Source.ToString().Contains("BaseLight")));

            if (currentTheme is { })
            {
                var themeIndex = Application.Current.Styles.IndexOf(currentTheme);

                var newTheme = new StyleInclude(new Uri($"avares://{nameof(XamlControlsGallery)}/App.xaml"))
                {
                    Source = new Uri($"avares://{nameof(XamlControlsGallery)}/Styles/Themes/Base{themeMode}.xaml")
                };

                
                CurrentTheme = themeMode;
                Application.Current.Styles[themeIndex] = newTheme;
            }

            
            
            // foreach (var VARIABLE in )
            // {
            //     
            // }


         }

        public static void ToggleTheme()
        {
            ApplyTheme(CurrentTheme == ThemeMode.Dark ? ThemeMode.Light : ThemeMode.Dark);
        }
    }
}
