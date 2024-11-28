using System;
using System.Collections.Generic;
using SuperJMN.Site.ViewModels;

namespace SuperJMN.Site.Sections.Main;

public class Works
{
    public static IEnumerable<Work> List()
    {
        return [
            new Work
            {
                Name = "Wasabi Wallet",
                Description = "The leading Bitcoin wallet for desktop featuring coinjoin",
                Site = new Uri("https://wasabiwallet.io"),
                Snapshot = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/Works/Wasabi.jpg"))
            },
            new Work
            {
                Name = "Zafiro Toolkit",
                Description = "Productivity toolkit for .NET developers to be functional and stay functional.",
                Site = new Uri("https://github.com/SuperJMN-Zafiro/Zafiro"),
                Snapshot = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/Works/Zafiro.jpg"))
            },
            new Work
            {
                Name = "DotnetPackaging",
                Description = "Package your applications!",
                Site = new Uri("https://github.com/SuperJMN/Deployer"),
                Snapshot = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/Works/DotnetPackaging.png"))
            },
            new Work
            {
                Name = "Deployer",
                Description = "Deployment framework with scripting engine",
                Site = new Uri("https://github.com/SuperJMN/Deployer"),
                Snapshot = ImageHelper.LoadFromResource(new Uri("avares://SuperJMN.Site/Assets/Works/Deployer.png"))
            }
        ];
    }
}