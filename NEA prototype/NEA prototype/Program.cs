using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NEA_prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            bool exit = false;
            int CurrentOptionMainMenu = 1;
            PrintMainMenu();
            Console.CursorLeft = 0;
            Console.CursorTop = CurrentOptionMainMenu;
            Console.Write(">");
            do
            {
                ConsoleKeyInfo choice = Console.ReadKey(true);
                if ((choice.Key == ConsoleKey.DownArrow || choice.Key == ConsoleKey.S) && CurrentOptionMainMenu < 6)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionMainMenu;
                    Console.Write(" ");
                    CurrentOptionMainMenu++;
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionMainMenu;
                    Console.Write(">");
                }
                else if ((choice.Key == ConsoleKey.UpArrow || choice.Key == ConsoleKey.W) && CurrentOptionMainMenu > 1)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionMainMenu;
                    Console.Write(" ");
                    CurrentOptionMainMenu--;
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionMainMenu;
                    Console.Write(">");
                }
                else if (choice.Key == ConsoleKey.Enter)
                {
                    if (CurrentOptionMainMenu == 1)
                    {
                        DisributionMenu();
                        PrintMainMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 2)
                    {
                        Pearsons pearsons = new Pearsons();
                        pearsons.Menu();
                        PrintMainMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 3)
                    {

                        PrintMainMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 4)
                    {

                        PrintMainMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 5)
                    {

                        PrintMainMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else exit = true;
                }
            } while (exit != true);
        }
        static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("  Distributions");
            Console.WriteLine("  PMCC");
            Console.WriteLine("  Goodness of Fit Tests");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  /*comming soon*/");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Quetions");
            Console.WriteLine("  Exit");
        }
        static void DisributionMenu()
        {
            bool ExitDistributionMenu = false;
            int CurrentOptionDistributionMenu = 1;
            PrintDistribuionMenu();
            Console.CursorLeft = 0;
            Console.CursorTop = CurrentOptionDistributionMenu;
            Console.Write(">");
            do
            {
                ConsoleKeyInfo choice = Console.ReadKey(true);
                if ((choice.Key == ConsoleKey.DownArrow || choice.Key == ConsoleKey.S) && CurrentOptionDistributionMenu < 5)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionDistributionMenu;
                    Console.Write(" ");
                    CurrentOptionDistributionMenu++;
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionDistributionMenu;
                    Console.Write(">");
                }
                else if ((choice.Key == ConsoleKey.UpArrow || choice.Key == ConsoleKey.W) && CurrentOptionDistributionMenu > 1)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionDistributionMenu;
                    Console.Write(" ");
                    CurrentOptionDistributionMenu--;
                    Console.CursorLeft = 0;
                    Console.CursorTop = CurrentOptionDistributionMenu;
                    Console.Write(">");
                }
                else if (choice.Key == ConsoleKey.Enter)
                {
                    if (CurrentOptionDistributionMenu == 1)
                    {
                        Binomial Probability = new Binomial(0,0);
                        Probability.Menu();
                        PrintDistribuionMenu(); 
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionDistributionMenu;
                        Console.Write(">");

                    }
                    else if (CurrentOptionDistributionMenu == 2)
                    {
                        Geometric Probability = new Geometric(0);
                        Probability.Menu();
                        PrintDistribuionMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionDistributionMenu;
                        Console.Write(">");

                    }
                    else if(CurrentOptionDistributionMenu == 3)
                    {
                        Poisson Probability = new Poisson(0);
                        Probability.Menu();
                        PrintDistribuionMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionDistributionMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionDistributionMenu == 4)
                    {
                        Uniform Probability = new Uniform(0);
                        Probability.Menu();
                        PrintDistribuionMenu();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionDistributionMenu;
                        Console.Write(">");
                    }
                    else ExitDistributionMenu = true;
                }
            } while (ExitDistributionMenu != true);
        }
        static void PrintDistribuionMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("  Binomial");
            Console.WriteLine("  Geometric");
            Console.WriteLine("  Poisson");
            Console.WriteLine("  Uniform");
            Console.WriteLine("  Exit");
        }
    }
}
