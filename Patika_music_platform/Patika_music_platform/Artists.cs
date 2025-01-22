using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patika_music_platform
{
    internal class Artists
    {
        public string NameSurname { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public int ReleaseDate { get; set; }
        public int Sales { get; set; }

        public Artists(string nameSurname, string genre, string country, int releaseDate, int sales)
        {
            NameSurname = nameSurname;
            Genre = genre;
            Country = country;
            ReleaseDate = releaseDate;
            Sales = sales;
        }
    }
}
