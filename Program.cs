using System;

// Part 1: Book class
class Book
{
    // Book properties
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public bool IsAvailable { get; private set; }

    // Constructor
    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        IsAvailable = true;
    }

    // Display book information
    public virtual void DisplayInfo()
    {
        Console.WriteLine(
            $"Title: {Title} | Author: {Author} | ISBN: {Isbn} | Available: {IsAvailable}");
    }

    // Borrow a book
    public void Borrow()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"{Title} has been borrowed.");
        }
        else
        {
            Console.WriteLine($"Sorry, {Title} is already borrowed.");
        }
    }

    // Return a book
    public void Return()
    {
        IsAvailable = true;
        Console.WriteLine($"{Title} has been returned.");
    }
}

// Part 2: EBook class inherits from Book
class EBook : Book
{
    // Additional property
    public double FileSizeMb { get; set; }

    // Constructor
    public EBook(string title, string author, string isbn, double fileSizeMb)
        : base(title, author, isbn)
    {
        FileSizeMb = fileSizeMb;
    }

    // Override DisplayInfo method
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"File size: {FileSizeMb} MB");
    }
}

// Part 3: Main program
class Program
{
    static void Main(string[] args)
    {
        // Create two Book objects
        Book book1 = new Book("C# Basics", "A. Cruz", "111");
        Book book2 = new Book("OOP Made Easy", "M. Reyes", "222");

        // Create one EBook object
        EBook ebook1 = new EBook("Learn .NET", "J. Lim", "333", 4.5);

        // Display all book information
        Console.WriteLine("LIBRARY BOOK INFORMATION");
        Console.WriteLine();

        book1.DisplayInfo();
        book2.DisplayInfo();
        ebook1.DisplayInfo();

        Console.WriteLine();

        // Borrow the same book twice
        book1.Borrow();
        book1.Borrow();

        Console.WriteLine();

        // Return the book
        book1.Return();

        // Display updated information
        book1.DisplayInfo();

        Console.WriteLine();

        // Demonstrate polymorphism
        Book polymorphicBook = ebook1;

        Console.WriteLine("Polymorphism demo:");
        polymorphicBook.DisplayInfo();

        Console.WriteLine();
        Console.WriteLine("Program completed successfully!");
    }
}