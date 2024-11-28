using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Metadata;

namespace SuperJMN.Site.Sections.Main;

public class Section : TemplatedControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<Section, string>(
        nameof(Title));

    public static readonly StyledProperty<object> ContentProperty = AvaloniaProperty.Register<Section, object>(
        nameof(Content));

    public static readonly StyledProperty<TextAlignment> TitleAlignmentProperty = AvaloniaProperty.Register<Section, TextAlignment>(
        nameof(TitleAlignment));

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    [Content]
    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public TextAlignment TitleAlignment
    {
        get => GetValue(TitleAlignmentProperty);
        set => SetValue(TitleAlignmentProperty, value);
    }
}