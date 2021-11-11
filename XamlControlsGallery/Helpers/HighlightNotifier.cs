using AvaloniaEdit.Highlighting;
using ReactiveUI;

namespace XamlControlsGallery.Helpers;

public class HighlightNotifier : ReactiveObject
{
    private IHighlightingDefinition _definition;

    public IHighlightingDefinition Definition
    {
        get => _definition;
        set => this.RaiseAndSetIfChanged(ref _definition, value, nameof(Definition));
    }
}
