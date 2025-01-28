using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class Library
    {
        public static List<Author> Authors = new List<Author>
        {
            new Author { AuthorId = 1, Name = "J.K. Rowling" },
            new Author { AuthorId = 2, Name = "George Orwell" },
            new Author { AuthorId = 3, Name = "J.R.R. Tolkien" }
        };

        public static List<Book> Books = new List<Book>
        {
            new Book { BookId = 1, Title = "Harry Potter", AuthorId = 1 },
            new Book { BookId = 2, Title = "1984", AuthorId = 2 },
            new Book { BookId = 3, Title = "Animal Farm", AuthorId = 2 },
            new Book { BookId = 4, Title = "The Hobbit", AuthorId = 3 }
        };

        public static void DisplayBooksWithAuthors()
        {
            var bookDetails = from book in Books
                              join author in Authors on book.AuthorId equals author.AuthorId
                              select new { book.BookId, book.Title, author.Name };

            Console.WriteLine("Books and their Authors:");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("ID  | Title            | Author");
            Console.WriteLine("----------------------------------");

            foreach (var item in bookDetails)
            {
                Console.WriteLine($"{item.BookId,-3} | {item.Title,-15} | {item.Name}");
            }
        }
    }
}
