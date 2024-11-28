using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace SuperJMN.Site.Core;

public class TypewriterBanner : TemplatedControl
{
    public static readonly DirectProperty<TypewriterBanner, string> TextToWriteProperty = AvaloniaProperty.RegisterDirect<TypewriterBanner, string>(
        nameof(TextToWrite), o => o.TextToWrite, (o, v) => o.TextToWrite = v);

    public static readonly StyledProperty<IEnumerable<string>> StringsProperty = AvaloniaProperty.Register<TypewriterBanner, IEnumerable<string>>(
        nameof(Strings));

    private string textToWrite;

    public string TextToWrite
    {
        get => textToWrite;
        set => SetAndRaise(TextToWriteProperty, ref textToWrite, value);
    }

    public IEnumerable<string> Strings
    {
        get => GetValue(StringsProperty);
        set => SetValue(StringsProperty, value);
    }
}