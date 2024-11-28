using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace SuperJMN.Site;

public class TypewriterBanner : TemplatedControl
{
    private string textToWrite;

    public static readonly DirectProperty<TypewriterBanner, string> TextToWriteProperty = AvaloniaProperty.RegisterDirect<TypewriterBanner, string>(
        nameof(TextToWrite), o => o.TextToWrite, (o, v) => o.TextToWrite = v);

    public string TextToWrite
    {
        get => textToWrite;
        set => SetAndRaise(TextToWriteProperty, ref textToWrite, value);
    }

    public static readonly StyledProperty<IEnumerable<string>> StringsProperty = AvaloniaProperty.Register<TypewriterBanner, IEnumerable<string>>(
        nameof(Strings));

    public IEnumerable<string> Strings
    {
        get => GetValue(StringsProperty);
        set => SetValue(StringsProperty, value);
    }
}