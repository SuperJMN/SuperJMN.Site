using System.Collections.Generic;
using ReactiveUI;
using SuperJMN.Site.ViewModels;

namespace SuperJMN.Site.Sections.Main;

public class MainViewModel : ViewModelBase
{
    private string textToTypeWrite;

    public MainViewModel()
    {
        Skills = Main.Skills.List();

        Experiences = Main.Experiences.List();

        Works = Main.Works.List();

        SocialNetworks = Main.SocialNetworks.List();

        FunFacts = Main.FunFacts.List();
    }

    public IEnumerable<FunFact> FunFacts { get; set; }

    public IEnumerable<Social> SocialNetworks { get; }
    public IEnumerable<Skill> Skills { get; }
    public IEnumerable<Experience> Experiences { get; }
    public IEnumerable<Work> Works { get; }

    public string TextToTypeWrite
    {
        get => textToTypeWrite;
        set => this.RaiseAndSetIfChanged(ref textToTypeWrite, value);
    }
}