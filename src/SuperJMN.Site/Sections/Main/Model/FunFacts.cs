using System;
using System.Collections.Generic;
using SuperJMN.Site.ViewModels;

namespace SuperJMN.Site.Sections.Main;

public class FunFacts
{
    public static IEnumerable<FunFact> List()
    {
        return [
            new FunFact
            {
                Description = "Github Repos",
                Value = 141,
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/SocialNetworks/GitHub.png"))
            },
            new FunFact
            {
                Description = "Github Stars gathered",
                Value = 247,
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/FunFacts/GitHubStar.png"))
            },
            new FunFact
            {
                Description = "Precious wife",
                Value = 1,
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/FunFacts/Wife.png"))
            },
            new FunFact
            {
                Description = "Precious child",
                Value = 1,
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/FunFacts/Child.png"))
            }
        ];
    }
}