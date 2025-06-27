using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NEA_prototype
{
    internal class Uniform : ParentProbabilityClass
    {
        protected double totalnum;
        public Uniform(int totalnum) : base()
        {
            UpdateVariables(totalnum);
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
                if ((choice.Key == ConsoleKey.DownArrow || choice.Key == ConsoleKey.S) && CurrentOptionMainMenu < 4)
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
                        UpdateVariables(GetNewTotalNum());
                        MainMenuChoices();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 2)
                    {
                        Console.Clear();
                        Console.Write($"P(X = x) : {probability}");
                        Console.ReadKey(true);
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
            Console.WriteLine("  Set the total amount of values");
            Console.WriteLine("  Probability");
            Console.WriteLine("  Expected Value");
            Console.WriteLine("  Varience");
            Console.WriteLine("  Exit");
        }
        protected void UpdateVariables(int totalnum)
        {
            this.totalnum = totalnum;
            probability = Math.Pow(totalnum, -1);
            expectedvalue = (totalnum + 1) / 2;
            varience = (Math.Pow(totalnum, 2) - 1) / 12;
        }
        protected double GetProbability()
        {
            return probability;
        }
        public int GetNewTotalNum()
        {
            Console.Clear();
            Console.Write("Totalnum : ");
            return int.Parse(Console.ReadLine());
        }
    }
}