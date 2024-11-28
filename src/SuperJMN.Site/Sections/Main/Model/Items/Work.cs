using System;
using Avalonia.Media.Imaging;

namespace SuperJMN.Site.Sections.Main;

public class Work
{
    public string Name { get; set; }
    public Bitmap Snapshot { get; set; }
    public Uri Site { get; set; }
    public string Description { get; set; }
}