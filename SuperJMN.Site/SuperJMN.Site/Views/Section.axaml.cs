using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;

namespace SuperJMN.Site.Views;

public partial class Section : TemplatedControl
{

    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<Section, string>(
        nameof(Title));

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly StyledProperty<object> ContentProperty = AvaloniaProperty.Register<Section, object>(
        nameof(Content));

    [Content]
    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}