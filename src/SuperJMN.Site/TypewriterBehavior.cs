using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Avalonia.Xaml.Interactions.Custom;
using ReactiveUI;

namespace SuperJMN.Site;

public class TypewriterBehavior : DisposingBehavior<TextBlock>
{
    protected override void OnAttached(CompositeDisposable disposables)
    {
        this.WhenAnyValue(x => x.TextToType)
            .WhereNotNull()
            .Throttle(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler)
            .Select(s => Remove(AssociatedObject.Text).Concat(Add(TextToType)))
            .Switch()
            .Do(text => AssociatedObject.Text = text)
            .Subscribe();
    }

    private IObservable<string> Add(string text)
    {
        return Enumerable.Range(0, text.Length)
            .Reverse()
            .ToObservable()
            .Select(i => Observable.Return(text[..^i]).Delay(TimeSpan.FromMilliseconds(50), AvaloniaScheduler.Instance))
            .Concat();
    }

    private IObservable<string> Remove(string text)
    {
        return Enumerable.Range(0, text.Length)
            .ToObservable()
            .Select(i => Observable.Return(text[..^i]).Delay(TimeSpan.FromMilliseconds(50), AvaloniaScheduler.Instance))
            .Concat();
    }

    public static readonly StyledProperty<string> TextToTypeProperty = AvaloniaProperty.Register<TypewriterBehavior, string>(
        nameof(TextToType));

    public string TextToType
    {
        get => GetValue(TextToTypeProperty);
        set => SetValue(TextToTypeProperty, value);
    }

    public IObservable<Unit> Done { get; }
}