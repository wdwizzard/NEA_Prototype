using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NEA_prototype
{
    internal class Binomial:ParentProbabilityClass
    {
        protected int totalnum;
        public Binomial(double probability, int totalnum) : base()
        {
            UpdateVariables(probability, totalnum);
        }
        public void Menu()
        {
            bool exit = false;
            int CurrentOptionMainMenu = 1;
            MainMenuChoices();
            Console.CursorLeft = 0;
            Console.CursorTop = CurrentOptionMainMenu;
            Console.Write(">");
            do
            {
                ConsoleKeyInfo choice = Console.ReadKey(true);
                if ((choice.Key == ConsoleKey.DownArrow || choice.Key == ConsoleKey.S) && CurrentOptionMainMenu < 5)
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
                        UpdateVariables(GetNewProbability(), totalnum);
                        MainMenuChoices();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 2)
                    {
                        UpdateVariables(probability, GetNewTotalNum());
                        MainMenuChoices();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 3)
                    {
                        Console.Clear();
                        Console.Write($"E(x) : {GetEX()}");
                        Console.ReadKey(true);
                        MainMenuChoices();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 4)
                    {
                        Console.Clear();
                        Console.Write($"Var(x) : {GetVarX()}");
                        Console.ReadKey(true);
                        MainMenuChoices();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else exit = true;
                }
            } while (exit != true);
        }
        protected void MainMenuChoices()
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("  Set Probabilitiy");
            Console.WriteLine("  Set the total amount of values");
            Console.WriteLine("  Expected Value");
            Console.WriteLine("  Varience");
            Console.WriteLine("  Exit");
        }
        protected void UpdateVariables(double probability, int totalnum)
        {
            this.probability = probability;
            this.totalnum = totalnum;
            expectedvalue = totalnum * probability;
            varience = expectedvalue * (1 - probability);
        }
        public double GetNewProbability()
        {
            Console.Clear();
            Console.Write("Probability : ");
            return double.Parse(Console.ReadLine());
        }
        public int GetNewTotalNum()
        {
            Console.Clear();
            Console.Write("Totalnum : ");
            return int.Parse(Console.ReadLine());
        }
    }
}