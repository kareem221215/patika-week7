using System;
using System.Collections.Generic;
using System.Linq;

namespace Patika_music_platform
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Artists> artists = new List<Artists>
            {
                new Artists("Billie Eilish", "Pop", "USA", 2015, 1500000),
                new Artists("Dua Lipa", "Pop", "UK", 2015, 100000),
                new Artists("Ed Sheeran", "Pop", "UK", 2011, 3000000),
                new Artists("Eminem", "Rap", "USA", 1996, 2000000),
                new Artists("Lady Gaga", "Pop", "USA", 2008, 1700000),
                new Artists("Lana Del Rey", "Pop", "USA", 2011, 2400000),
                new Artists("Lorde", "Pop", "NZ", 2012, 1300000),
                new Artists("Taylor Swift", "Pop", "USA", 2006, 10),
                new Artists("The Weeknd", "R&B", "CAN", 2010, 2000000),
                new Artists("Zayn", "Pop", "UK", 2010, 60000)
            };

            var artist = artists.Where(i => i.NameSurname.StartsWith("S")).FirstOrDefault();
            var sales = artists.Where(i => i.Sales > 1000000);
            var country = artists.Where(i => i.ReleaseDate < 2000 && i.Genre == "Pop");
            var DubutYear = artists.OrderByDescending(i => i.ReleaseDate);
            var groupedArtists = artists
                .GroupBy(i => i.Genre)
                .OrderBy(g => g.Key)  // Sort groups by genre alphabetically
                .Select(g => new
                {
                    Genre = g.Key,
                    Artists = g.OrderBy(i => i.NameSurname) // Sort each group alphabetically by name
                });

            var Max = artists.Max(i => i.Sales);
            var OldestArtist = artists.OrderBy(i => i.ReleaseDate).FirstOrDefault();
            var NewestArtist = artists.OrderByDescending(i => i.ReleaseDate).FirstOrDefault();

            PrintResults("Artist name starts with S", artist != null ? new[] { artist } : Enumerable.Empty<Artists>());
            PrintResults("Artist sales above 1 million", sales);
            PrintResults("Artist debut before 2000 and make pop music", country);
            PrintResults("Artist debut year", DubutYear);
            PrintResults("Artist with the highest album sales", new[] { artists.First(a => a.Sales == Max) });
            PrintResults("The most recent and earliest debuting artists", new[] { OldestArtist, NewestArtist });
            PrintGroupedResults("Grouped artists", groupedArtists);
        }
        static void PrintResults(string title, IEnumerable<Artists> artists)
        {
            Console.WriteLine($"{title}: ");
            if (artists.Any()) // Check if there are any artists to display
            {
                Console.WriteLine(string.Join(", ", artists.Select(a => a.NameSurname)));
            }
            else
            {
                Console.WriteLine("No artists found.");
            }
            Console.WriteLine();
        }

        static void PrintGroupedResults(string title, IEnumerable<dynamic> groupedArtists)
        {
            Console.WriteLine($"{title}: ");
            foreach (var group in groupedArtists)
            {
                Console.WriteLine($"Genre: {group.Genre}");
                foreach (var artist in group.Artists)
                {
                    Console.WriteLine($"  {artist.NameSurname}");
                }
            }
            Console.WriteLine();
        }
    }
}