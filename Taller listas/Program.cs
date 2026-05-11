using System;

namespace TallerListas
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> myList = new MyList<string>();
            int option = -1;

            while (option != 0)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Add | 2. Show Forward | 3. Show Backward | 4. Sort Desc");
                Console.WriteLine("5. Modes | 6. Graph | 7. Exists | 8. Rem One | 9. Rem All | 0. Exit");
                Console.Write("Choose: ");

                if (!int.TryParse(Console.ReadLine(), out option)) continue;

                switch (option)
                {
                    case 1:
                        Console.Write("Enter value: ");
                        string? val = Console.ReadLine();
                        if (!string.IsNullOrEmpty(val)) myList.Add(val);
                        break;
                    case 2: myList.ShowForward(); break;
                    case 3: myList.ShowBackward(); break;
                    case 4: myList.SortDescending(); break;
                    case 5: myList.ShowMode(); break;
                    case 6: myList.ShowGraph(); break;
                    case 7:
                        Console.Write("Search for: ");
                        Console.WriteLine(myList.Exists(Console.ReadLine() ?? "") ? "Yes" : "No");
                        break;
                    case 8:
                        Console.Write("Remove one: ");
                        myList.RemoveOne(Console.ReadLine() ?? "");
                        break;
                    case 9:
                        Console.Write("Remove all: ");
                        myList.RemoveAll(Console.ReadLine() ?? "");
                        break;
                }
            }
        }
    }
}