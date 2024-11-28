using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Avalonia.Xaml.Interactions.Custom;
using ReactiveUI;

namespace SuperJMN.Site
{
    public class CyclingTypewriterBehavior : DisposingBehavior<TextBlock>
    {
        protected override void OnAttached(CompositeDisposable disposables)
        {
            Observable.Defer(() =>
                {
                    return this.WhenAnyValue(x => x.Strings)
                        .WhereNotNull()
                        .Take(1)
                        .Throttle(TimeSpan.FromSeconds(1), AvaloniaScheduler.Instance)
                        .Select(strings => strings.ToObservable()) // Convierte IEnumerable<string> a IObservable<string>
                        .Switch() // Cambia a la nueva secuencia si Strings cambia
                        .Select(to => Observable.Defer(() => Type(AssociatedObject.Text ?? "", to))) // Mapea cada string a su TypingSequence
                        .Concat();
                })
                .Repeat() // Repite la secuencia completa indefinidamente
                .Subscribe();
        }

        private IObservable<string> Type(string from, string to)
        {
            return DeleteAndType(from, to).Do(s => AssociatedObject.Text = s);
        }

        private IObservable<string> DeleteAndType(string toDelete, string toType)
        {
            return Remove(toDelete).Concat(Add(toType));
        }

        private IObservable<string> Add(string text)
        {
            return Enumerable.Range(0, text.Length)
                .Reverse()
                .ToObservable()
                .Select(i => Observable.Return(text[..^i]).Delay(TimeSpan.FromMilliseconds(500), AvaloniaScheduler.Instance))
                .Concat();
        }

        private IObservable<string> Remove(string text)
        {
            return Enumerable.Range(0, text.Length)
                .ToObservable()
                .Select(i => Observable.Return(text[..^i]).Delay(TimeSpan.FromMilliseconds(500), AvaloniaScheduler.Instance))
                .Concat();
        }

        public static readonly StyledProperty<IEnumerable<string>> StringsProperty =
            AvaloniaProperty.Register<CyclingTypewriterBehavior, IEnumerable<string>>(nameof(Strings));

        public IEnumerable<string> Strings
        {
            get => GetValue(StringsProperty);
            set => SetValue(StringsProperty, value);
        }
    }
}