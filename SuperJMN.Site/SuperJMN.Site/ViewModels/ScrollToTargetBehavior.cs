using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using Avalonia.Xaml.Interactions.Custom;
using CSharpFunctionalExtensions;
using Zafiro.Avalonia.Mixins;

namespace SuperJMN.Site.ViewModels;

public class ScrollToTargetBehavior : AttachedToVisualTreeBehavior<InputElement>
{
    public static readonly AttachedProperty<string> TargetIdProperty =
        AvaloniaProperty.RegisterAttached<ScrollToTargetBehavior, AvaloniaObject, string>("TargetId");

    public string TargetId { get; set; }

    public static void SetTargetId(AvaloniaObject obj, string value)
    {
        obj.SetValue(TargetIdProperty, value);
    }

    public static string GetTargetId(AvaloniaObject obj)
    {
        return obj.GetValue(TargetIdProperty);
    }

    protected override void OnAttachedToVisualTree(CompositeDisposable disposable)
    {
        if (AssociatedObject is null)
        {
            return;
        }

        AssociatedObject.OnEvent(InputElement.PointerPressedEvent, RoutingStrategies.Tunnel)
            .Do(_ =>
            {
                GetScrollViewer(AssociatedObject)
                    .Execute(scrollViewer => GetTarget(scrollViewer)
                        .Execute(visual => ScrollToTarget(scrollViewer, visual)));
            })
            .Subscribe()
            .DisposeWith(disposable);

        base.OnAttached(disposable);
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

        var targetRectInScrollViewer = transform.Value.Transform(targetBounds.TopLeft);
        scrollViewer.Offset = new Vector(scrollViewer.Offset.X, targetRectInScrollViewer.Y + scrollViewer.Offset.Y);
    }
}