using System;
using System.Collections.Generic;
using SuperJMN.Site.ViewModels;

namespace SuperJMN.Site.Sections.Main;

public class SocialNetworks
{
    public static IEnumerable<Social> List()
    {
        return [
            new Social
            {
                Name = "Github",
                Link = new Uri("https://github.com/SuperJMN"),
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/SocialNetworks/GitHub.png"))
            },
            new Social
            {
                Name = "LinkedIn",
                Link = new Uri("https://linkedin.com/in/SuperJMN"),
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/SocialNetworks/LinkedIn.png"))
            },
            new Social
            {
                Name = "X",
                Link = new Uri("https://x.com/SuperJMN"),
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/SocialNetworks/X.png"))
            }
        ];
    }
}