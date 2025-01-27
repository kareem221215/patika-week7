using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<TV_shows> TV_shows = new List<TV_shows>();

            bool keepGoing = true;
            do 
            {
                Console.WriteLine("enter  name of series: ");
                string nameOfSeries = Console.ReadLine();

                Console.WriteLine("production date: ");
                int productionYear = int.Parse(Console.ReadLine());

                Console.WriteLine("type of series: ");
                string genre = Console.ReadLine();

                Console.WriteLine("Year to  be published: ");
                int toBePublished = int.Parse(Console.ReadLine());

                Console.WriteLine("Directors name: ");
                string directors = Console.ReadLine();

                Console.WriteLine("Published platform: ");
                string channels = Console.ReadLine();

                TV_shows.Add(new TV_shows
                {
                    NameOfSeries = nameOfSeries,
                    ProductionYear = productionYear,
                    Genre = genre,
                    ToBePublished = toBePublished,
                    Directors = directors,
                    Channels = channels
                });

                Console.WriteLine("do you wanna add another series? (yes/no) ");
                if (Console.ReadLine().ToLower() == "no")
                {
                    keepGoing = false;
                }


            } while (keepGoing);

            var comedyShows = TV_shows.Where(show => show.Genre == "Comedy");

            List<SimpleShow> simpleShowList = comedyShows
                .Select(show => new SimpleShow
                {
                    NameOfSeries = show.NameOfSeries,
                    Genre = show.Genre,
                    Directors = show.Directors
                })
                .ToList();

            var sortedSimpleShows = simpleShowList
               .OrderBy(show => show.NameOfSeries)  
               .ThenBy(show => show.Directors)     
               .ToList();

            foreach (var show in simpleShowList)
            {
                Console.WriteLine($"Name of series: {show.NameOfSeries}");
                Console.WriteLine($"Genre: {show.Genre}");
                Console.WriteLine($"Directors: {show.Directors}");
            }


        }
    }
}
