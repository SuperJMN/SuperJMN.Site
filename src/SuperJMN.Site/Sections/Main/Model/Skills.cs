using System.Collections.Generic;

namespace SuperJMN.Site.Sections.Main;

public class Skills
{
    public static IEnumerable<Skill>? List()
    {
        return [
            new Skill
            {
                Name = "C#",
                Percent = 100
            },
            new Skill
            {
                Name = "Avalonia",
                Percent = 93
            },
            new Skill
            {
                Name = "Reactive programming",
                Percent = 95
            },
            new Skill
            {
                Name = "Compilers & parsers",
                Percent = 60
            },
            new Skill
            {
                Name = "Kubernetes",
                Percent = 35
            },
            new Skill
            {
                Name = "Perfection seeking",
                Percent = 86
            },
            new Skill
            {
                Name = "Analytical skills",
                Percent = 90
            },
            new Skill
            {
                Name = "Best .NET dev in the world (working hard to it!)",
                Percent = 65
            }
        ];
    }
}