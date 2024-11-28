using Avalonia.Controls.Primitives;

namespace SuperJMN.Site.Core;

public class CaretControl : TemplatedControl
{
    // protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    // {
    //     base.OnApplyTemplate(e);
    //     
    //     var caret = e.NameScope.Find<Visual>("PART_Caret");
    //     
    //     if (caret == null)
    //     {
    //         return;
    //     }
    //     
    //     var animation = new Animation
    //     {
    //         Duration = TimeSpan.FromSeconds(2),
    //         IterationCount = IterationCount.Infinite,
    //         Easing = new LinearEasing()
    //     };
    //     
    //     animation.Children.AddRange(new KeyFrames
    //     {
    //         new KeyFrame
    //         {
    //             Cue = new Cue(0),
    //             Setters = { new Setter(Button.OpacityProperty, 1) }
    //         },
    //         new KeyFrame
    //         {
    //             Cue = new Cue(0.5),
    //             Setters = { new Setter(Button.OpacityProperty, 0) }
    //         },
    //         new KeyFrame
    //         {
    //             Cue = new Cue(1),
    //             Setters = { new Setter(Button.OpacityProperty, 1) }
    //         }
    //     });
    //
    //     animation.RunAsync(caret);
    // }
}