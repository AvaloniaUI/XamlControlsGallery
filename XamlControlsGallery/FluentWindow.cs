using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Platform;
using Avalonia.Controls.Primitives;

namespace Avalonia.Controls
{
    public class FluentWindow : Window, IStyleable
    {
        Type IStyleable.StyleKey => typeof(Window);

        public FluentWindow()
        {
            ExtendClientAreaToDecorationsHint = true;
            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.SystemChromeButtons;
            ExtendClientAreaTitleBarHeightHint = -1;

            TransparencyLevelHint = WindowTransparencyLevel.Blur;            

            this.GetObservable(WindowStateProperty)
                .Subscribe(x =>
                {
                    PseudoClasses.Set(":maximized", x == WindowState.Maximized);
                    PseudoClasses.Set(":fullscreen", x == WindowState.FullScreen);
                });

            this.GetObservable(IsExtendedIntoWindowDecorationsProperty)
                .Subscribe(x =>
                {
                    if(!x)
                    {
                        SystemDecorations = SystemDecorations.BorderOnly;                                                
                    }
                });
        }        

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);            
        }
    }
}
