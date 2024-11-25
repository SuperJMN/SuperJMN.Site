using System.Linq;
using Avalonia.Data.Converters;

namespace SuperJMN.Site;

public class HeaderHeightConverter
{
    public static FuncMultiValueConverter<double, double> Instance = new(d =>
    {
        var list = d.ToList();
        return list[1] - list[0];
    });
}