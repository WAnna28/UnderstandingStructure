using System;

namespace UnderstandingStructure
{
    struct Book
    {
        public string Title;
        public string Author;
        public string Subject;
        public int BookID;

        // A custom constructor.
        public Book(string title, string author, string subject, int bookID)
        {
            Title = title;
            Author = author;
            Subject = subject;
            BookID = bookID;
        }

        public void Display()
        {
            Console.WriteLine("Title : {0}", Title);
            Console.WriteLine("Author : {0}", Author);
            Console.WriteLine("Subject : {0}", Subject);
            Console.WriteLine("BookID :{0}", BookID);
            Console.WriteLine();
        }
    };

    // Using Read-Only Structs (New 7.2)
    // Structs can also be marked as read-only if there is a need for them to be immutable.
    // Immutable objects must be set up at construction.
    readonly struct ReadOnlyPoint
    {
        public int X { get; }
        public int Y { get; }

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
        public ReadOnlyPoint(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
    }

    // Using Read-Only Members (New 8.0)
    // New in C# 8.0, you can declare individual fields of a struct as readonly.
    // This is more granular than making the entire struct read-only.
    // The readonly modifier can be applied to methods, properties, and property accessors.
    struct PointWithReadOnly
    {
        public int X;
        public readonly int Y;
        public readonly string Name;

        public readonly void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}, Name = {Name}");
        }

        // A custom constructor.
        public PointWithReadOnly(int xPos, int yPos, string name)
        {
            X = xPos;
            Y = yPos;
            Name = name;
        }
    }

    // Using ref Structs (New 7.2)
    // With C# 7.2 we now have the ability to create the ref struct.
    // What this does is create a struct that can only live on the stack.
    //  ref struct can be a:
    //  1. Method Parameter
    //  2. A return type of a method
    //  3. A local variable
    ref struct CustomRefStruct
    {
    }

    // ref struct cannot be part of a class, whether it be static or instance member.
    //class CustomClass
    //{
    //    public int IntValue { get; set; }

    //    public CustomRefStruct StructValue { get; set; }
    //}

    // Using Disposable ref Structs (New 8.0)
    // New in C# 8.0, ref structs and read-only ref structs can be
    // made disposable by adding a public void Dispose() method.
    ref struct DisposableRefStruct
    {
        public int X;
        public readonly int Y;
        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }

        // A custom constructor.
        public DisposableRefStruct(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
            Console.WriteLine("Created!");
        }

        public void Dispose()
        {
            //clean up any resources here
            Console.WriteLine("Disposed!");
        }
    }

    class Program
    {
        static void Main()
        {
            CreatingStructureVariables();
            UseReadOnlyPoint();
            UsePointWithReadOnly();
            UseRefStruct();
            UseDisposableRefStruct();

            Console.ReadLine();
        }

        static void CreatingStructureVariables()
        {
            Book b;
            b.Author = "Unknown";
            b.Title = "Summer School";
            b.Subject = "Understanding the Structure";
            b.BookID = 20212008;
            b.Display();

            // If you do not assign each piece of public field data before using the structure,
            // you will receive a compiler error.
            Book oldBook;
            oldBook.BookID = 12052004;
            //oldBook.Display();

            // Set all fields to default values using the default constructor.
            Book newBook = new Book();
            newBook.BookID = 20210909;
            newBook.Display();

            // Call custom constructor.
            Book book = new Book("DotNET5", "Troelsen", "Programming", 4578);
            book.Display();
        }

        static void UseReadOnlyPoint()
        {
            ReadOnlyPoint rop = new ReadOnlyPoint(15, 78);
            rop.Display();
            Console.WriteLine();
        }

        static void UsePointWithReadOnly()
        {
            PointWithReadOnly pwro = new PointWithReadOnly(15, 78, "test");
            pwro.Display();
            pwro.X = 2021;
           // pwro.Y = 20;
            //pwro.Name = "illegal";
            pwro.Display();
            Console.WriteLine();
        }

        static void UseRefStruct()
        {
            //// Cannot implicitly convert 
            //var s = new CustomRefStruct();
            //Object boxed = s;
        }

        static void UseDisposableRefStruct()
        {
            var s = new DisposableRefStruct(50, 60);
            s.Display();
            s.Dispose();

            Console.WriteLine();
        }
    }
}