using System;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using Avalonia;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using Avalonia.Styling;
using AvaloniaEdit.Highlighting;
using AvaloniaEdit.Highlighting.Xshd;
using JetBrains.Annotations;

namespace XamlControlsGallery.Helpers
{
    public static class ThemeHelper
    {
        public static ThemeMode CurrentTheme { get; private set; }

        public static HighlightNotifier HighlightNotifierInstance = new();

        [CanBeNull]
        private static StyleInclude
            CurrentThemeStyles => Application.Current.Styles
            .Select(x => (StyleInclude)x)
            .FirstOrDefault(x =>
                x.Source is { } && (x.Source.ToString().Contains("BaseDark") ||
                                    x.Source.ToString().Contains("BaseLight")));

        public static void ApplyTheme(ThemeMode themeMode)
        {
            if (CurrentThemeStyles is { })
            {
                var themeIndex = Application.Current.Styles.IndexOf(CurrentThemeStyles);

                var newTheme = new StyleInclude(new Uri($"avares://{nameof(XamlControlsGallery)}/App.axaml"))
                {
                    Source = new Uri($"avares://{nameof(XamlControlsGallery)}/Styles/Themes/Base{themeMode}.axaml")
                };

                CurrentTheme = themeMode;
                Application.Current.Styles[themeIndex] = newTheme;

                ApplySyntaxHighlighting();
            }
        }

        public static void ApplySyntaxHighlighting()
        {
            if (CurrentThemeStyles.Loaded is not Styles curThemeStyles) return;

            var name = typeof(ThemeHelper).Assembly.GetManifestResourceNames().First(x => x.Contains("xml.xshd"));
            using var sr = (typeof(ThemeHelper).Assembly.GetManifestResourceStream(name));
            using var reader = new XmlTextReader(sr);

            var newHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
            
            foreach (var syntaxColor in curThemeStyles
                         .Resources
                         .Where(x => x.Key.ToString().StartsWith("XamlCode"))
                         .Select(x => (x.Key.ToString().Replace("XamlCode", ""), (Color)x.Value)))
            {
                var targetHighlightColor = newHighlighting.NamedHighlightingColors
                    .FirstOrDefault(c => c.Name == syntaxColor.Item1);

                if (targetHighlightColor is null)
                    continue;

                targetHighlightColor.Foreground = new SimpleHighlightingBrush(syntaxColor.Item2);
            }

            HighlightNotifierInstance.Definition = newHighlighting;
        }

        public static void ToggleTheme()
        {
            ApplyTheme(CurrentTheme == ThemeMode.Dark ? ThemeMode.Light : ThemeMode.Dark);
        }
    }
}
