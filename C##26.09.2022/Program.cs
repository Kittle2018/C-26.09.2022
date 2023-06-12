using System;
using System.Collections.Generic;

namespace BookListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookList bookList = new BookList();

            bookList.Add(new Book("The Catcher in the Rye", "J.D. Salinger"));
            bookList.Add(new Book("To Kill a Mockingbird", "Harper Lee"));
            bookList.Add(new Book("1984", "George Orwell"));

            Console.WriteLine("Список книг для чтения:");
            Console.WriteLine(bookList);

            Console.WriteLine("\nВведите название книги, которую хотите удалить:");
            string bookTitle = Console.ReadLine();

            if (bookList.Remove(bookTitle))
            {
                Console.WriteLine($"Removed {bookTitle}");
                Console.WriteLine("Обновлен список книг для чтения:");
                Console.WriteLine(bookList);
            }
            else
            {
                Console.WriteLine($"{bookTitle} не нашел в списке.");
            }

            Console.ReadLine();
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }

    class BookList
    {
        private List<Book> books;

        public BookList()
        {
            books = new List<Book>();
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public bool Remove(string bookTitle)
        {
            Book bookToRemove = books.Find(b => b.Title == bookTitle);

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                return true;
            }

            return false;
        }

        public bool Contains(string bookTitle)
        {
            Book book = books.Find(b => b.Title == bookTitle);

            if (book != null)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string bookListString = "";

            foreach (Book book in books)
            {
                bookListString += $"{book}\n";
            }

            return bookListString;
        }

        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }
}
