using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Avalonia.Xaml.Interactions.Custom;
using CSharpFunctionalExtensions;
using Zafiro.Avalonia;
using Zafiro.Avalonia.Mixins;
using Zafiro.Reactive;

namespace SuperJMN.Site.ViewModels;

public class ScrollToTargetBehavior : AttachedToVisualTreeBehavior<InputElement>
{
    public static readonly AttachedProperty<string> TargetIdProperty =
        AvaloniaProperty.RegisterAttached<ScrollToTargetBehavior, AvaloniaObject, string>("TargetId");

    public ScrollToTargetBehavior()
    {
        
    }
    
    public string TargetId { get; set; }

    private SerialDisposable? scrollSubscription;

    protected override void OnDetaching()
    {
        scrollSubscription?.Dispose();
        base.OnDetaching();
    }

    public static void SetTargetId(AvaloniaObject obj, string value)
    {
        obj.SetValue(TargetIdProperty, value);
    }

    public static string GetTargetId(AvaloniaObject obj)
    {
        return obj.GetValue(TargetIdProperty);
    }

    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(DisposableMixins))]
    protected override void OnAttachedToVisualTree(CompositeDisposable disposable)
    {
        if (AssociatedObject is null)
        {
            return;
        }

        scrollSubscription = new();

        AssociatedObject.OnEvent(InputElement.PointerPressedEvent, RoutingStrategies.Tunnel)
            .Do(_ =>
            {
                var scroller = GetScrollViewer(AssociatedObject)
                    .Bind(scrollViewer => GetTarget(scrollViewer).Map(target => new{ scrollViewer, visual = target}))
                    .Map(arg => Scroller(arg.scrollViewer, arg.visual));
                
                if (scroller.HasValue && scrollSubscription.Disposable == null)
                {
                    scrollSubscription.Disposable = scroller.Value.Subscribe(_ => { }, onCompleted: () => scrollSubscription.Disposable = null);
                }
            })
            .Subscribe()
            .DisposeWith(disposable);

        base.OnAttached(disposable);
    }

    private IObservable<Unit> Scroller(ScrollViewer scrollViewer, Visual target)
    {
        return Observable.Interval(TimeSpan.FromMilliseconds(24), AvaloniaScheduler.Instance)
            .Select(_ => Step(scrollViewer, target))
            .TakeWhile(d => d > 3)
            .Do(d => scrollViewer.Offset = new Point(scrollViewer.Offset.X, scrollViewer.Offset.Y + d))
            .ToSignal();
    }

    private double Step(ScrollViewer scrollViewer, Visual target)
    {
        var targetBounds = target.Bounds;
        var transform = target.TransformToVisual(scrollViewer);

        if (transform == null)
        {
            return 0d;
        }

        var targetY = transform.Value.Transform(targetBounds.TopLeft).Y;
        var distance = targetY;

        var step = Math.Max(distance / 20, 5);

        if (Math.Abs(scrollViewer.Offset.Y + scrollViewer.Viewport.Height - scrollViewer.Extent.Height) < 20)
        {
            return 0;
        }

        if (distance > 0)
        {
            return step;
        }
        else
        {
            return -step;
        }
    }

    private static Maybe<ScrollViewer> GetScrollViewer(Visual visual)
    {
        return visual.GetVisualAncestors().OfType<ScrollViewer>().TryFirst();
    }

    private Maybe<Visual> GetTarget(Visual root)
    {
        return root.GetVisualDescendants().TryFirst(visual => GetTargetId(visual) == TargetId);
    }

    private static void ScrollToTarget(ScrollViewer scrollViewer, Visual target)
    {
        var targetBounds = target.Bounds;
        var transform = target.TransformToVisual(scrollViewer);

        if (transform == null)
        {
            return;
        }

        var currentOffset = scrollViewer.Offset.Y;
        var targetRectInScrollViewer = transform.Value.Transform(targetBounds.TopLeft);
        scrollViewer.Offset = new Vector(scrollViewer.Offset.X, targetRectInScrollViewer.Y + currentOffset);
    }
}