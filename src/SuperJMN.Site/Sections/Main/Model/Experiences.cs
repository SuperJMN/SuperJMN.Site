using System.Collections.Generic;

namespace SuperJMN.Site.Sections.Main;

public class Experiences
{
    public static IEnumerable<Experience> List()
    {
        return [
            new Experience
            {
                Name = "Wasabi Wallet",
                Description = "User interface & Code",
                YearStart = 2022,
                YearEnd = 2024
            },
            new Experience
            {
                Name = "Fluendo",
                Description = "Creating the next version of LongoMatch",
                YearStart = 2021,
                YearEnd = 2022
            },

            new Experience
            {
                Name = "Bravent",
                Description = "Working for companies like Microsoft, Banco Santander, LaLiga, Ibercaja…",
                YearStart = 2015,
                YearEnd = 2020
            },

            new Experience
            {
                Name = "Payvision",
                Description = "Fraud detection and payment processing.",
                YearStart = 2014,
                YearEnd = 2015
            },

            new Experience
            {
                Name = "DocPath",
                Description = "Creating DocPath’s Designer, a rich WYSIWYG designer to create documents and forms.",
                YearStart = 2012,
                YearEnd = 2014
            },

            new Experience
            {
                Name = "Quirón Salud",
                Description = "Building Casiopea application, integral healthcare solution",
                YearStart = 2011,
                YearEnd = 2012
            }
        ];
    }
}