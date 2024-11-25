using System;
using System.Collections;
using System.Collections.Generic;
using Avalonia.Media.Imaging;

namespace SuperJMN.Site.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Skills =
        [
            new Skill
            {
                Name = "C#",
                Percent = 100,
            },
            new Skill
            {
                Name = "Avalonia",
                Percent = 93,
            },
            new Skill
            {
                Name = "Reactive programming",
                Percent = 95,
            },
            new Skill
            {
                Name = "Compilers & parsers",
                Percent = 60,
            },
            new Skill
            {
                Name = "Kubernetes",
                Percent = 35,
            },
            new Skill
            {
                Name = "Perfection seeking",
                Percent = 86,
            },
            new Skill
            {
                Name = "Analytical skills",
                Percent = 90,
            },
            new Skill
            {
                Name = "Best .NET dev in the world (working hard to it!)",
                Percent = 65,
            }
        ];

        Experiences =
        [
            new Experience
            {
                Name = "Wasabi Wallet",
                Description = "User interface & Code",
                YearStart = 2022,
                YearEnd = 2024,
            },
            new Experience
            {
                Name = "Fluendo",
                Description = "Creating the next version of LongoMatch",
                YearStart = 2021,
                YearEnd = 2022,
            },

            new Experience
            {
                Name = "Bravent",
                Description = "Working for companies like Microsoft, Banco Santander, LaLiga, Ibercaja…",
                YearStart = 2015,
                YearEnd = 2020,
            },

            new Experience
            {
                Name = "Payvision",
                Description = "Fraud detection and payment processing.",
                YearStart = 2014,
                YearEnd = 2015,
            },

            new Experience
            {
                Name = "DocPath",
                Description = "Creating DocPath’s Designer, a rich WYSIWYG designer to create documents.",
                YearStart = 2012,
                YearEnd = 2014,
            },

            new Experience
            {
                Name = "Quirón Salud",
                Description = "Building Casiopea application, integral healthcare solution",
                YearStart = 2011,
                YearEnd = 2012,
            },
        ];

        Works =
        [
            new Work
            {
                Name = "Wasabi Wallet",
                Site = new Uri("https://wasabiwallet.io"),
                Snapshot = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/Works/Wasabi.jpg")),
            },
            new Work
            {
                Name = "Deployer",
                Site = new Uri("https://github.com/SuperJMN/Deployer"),
                Snapshot = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/Works/Deployer.png")),
            },
            new Work
            {
                Name = "Zafiro Toolkit",
                Site = new Uri("https://github.com/SuperJMN-Zafiro/Zafiro"),
                Snapshot = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/Works/Zafiro.jpg")),
            }
        ];

        SocialNetworks =
        [
            new Social
            {
                Name = "Github",
                Link = new Uri("https://github.com/SuperJMN/SuperJMN"),
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/SocialNetworks/GitHub.png"))
            },
            new Social
            {
                Name = "LinkedIn",
                Link = new Uri("https://linkedin.com/SuperJMN"),
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/SocialNetworks/LinkedIn.png"))
            }
            ,            new Social
            {
                Name = "X",
                Link = new Uri("https://x.com/SuperJMN"),
                Icon = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/SocialNetworks/X.png"))
            }

        ];
    }

    public IEnumerable<Social> SocialNetworks { get; }

    public IEnumerable<Skill> Skills { get; }
    public IEnumerable<Experience> Experiences { get; }
    public IEnumerable<Work> Works { get; }
}

public class Work
{
    public string Name { get; set; }
    public Bitmap Snapshot { get; set; }
    public Uri Site { get; set; }
}

public class Social
{
    public string Name { get; set; }
    public object Icon { get; set; }
    public Uri Link { get; set; }
}

public class Experience
{
    public int YearStart { get; set; }
    public int YearEnd { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class Skill
{
    public string Name { get; set; }
    public int Percent { get; set; }
}