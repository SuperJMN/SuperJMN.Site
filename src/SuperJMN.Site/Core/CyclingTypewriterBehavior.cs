using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls.Documents;
using Avalonia.Xaml.Interactions.Custom;
using ReactiveUI;
using Zafiro.Avalonia;

namespace SuperJMN.Site.Core;

public class CyclingTypewriterBehavior : DisposingBehavior<Run>
{
    public static readonly StyledProperty<Strings> StringsProperty =
        AvaloniaProperty.Register<CyclingTypewriterBehavior, Strings>(nameof(Strings));

    public static readonly StyledProperty<TimeSpan> TypingLatencyProperty = AvaloniaProperty.Register<CyclingTypewriterBehavior, TimeSpan>(
        nameof(TypingLatency), TimeSpan.FromMilliseconds(100));

    public static readonly StyledProperty<TimeSpan> InBetweenPauseProperty = AvaloniaProperty.Register<CyclingTypewriterBehavior, TimeSpan>(
        nameof(InBetweenPause), TimeSpan.FromSeconds(2));

    public Strings Strings
    {
        get => GetValue(StringsProperty);
        set => SetValue(StringsProperty, value);
    }

    public TimeSpan TypingLatency
    {
        get => GetValue(TypingLatencyProperty);
        set => SetValue(TypingLatencyProperty, value);
    }

    public TimeSpan InBetweenPause
    {
        get => GetValue(InBetweenPauseProperty);
        set => SetValue(InBetweenPauseProperty, value);
    }

    protected override void OnAttached(CompositeDisposable disposables)
    {
        this.WhenAnyValue(x => x.Some).Subscribe(obj => { });
        
        Observable.Defer(() => this.WhenAnyValue(x => x.Strings)
                .WhereNotNull()
                .Take(1)
                .Select(strings => strings.ToObservable()) // Convierte IEnumerable<string> a IObservable<string>
                .Switch() // Cambia a la nueva secuencia si Strings cambia
                .Select(to => Observable.Defer(() => Observable.Timer(InBetweenPause, AvaloniaScheduler.Instance).SelectMany(_ => Type(AssociatedObject.Text ?? "", to)))) // Mapea cada string a su TypingSequence
                .Concat())
            .Repeat() // Repeats the sequence indefinitely
            .Subscribe();
    }

    private IObservable<string> Type(string from, string to)
    {
        return DeleteAllAndType(from, to).Do(s => AssociatedObject.Text = s);
    }

    private IObservable<string> DeleteAllAndType(string toDelete, string toType)
    {
        return Remove(toDelete).Concat(Add(toType));
    }

    private IObservable<string> Add(string text)
    {
        return Enumerable.Range(0, text.Length)
            .Reverse()
            .ToObservable()
            .Select(i => Observable.Return(text[..^i]).Delay(TypingLatency, Avalonia.ReactiveUI.AvaloniaScheduler.Instance))
            .Concat();
    }

    private IObservable<string> Remove(string text)
    {
        return Enumerable.Range(0, text.Length)
            .ToObservable()
            .Select(i => Observable.Return(text[..^i]).Delay(TypingLatency, Avalonia.ReactiveUI.AvaloniaScheduler.Instance))
            .Concat();
    }

    public static readonly StyledProperty<object> SomeProperty = AvaloniaProperty.Register<CyclingTypewriterBehavior, object>(
        nameof(Some));

    public object Some
    {
        get => GetValue(SomeProperty);
        set => SetValue(SomeProperty, value);
    }
}