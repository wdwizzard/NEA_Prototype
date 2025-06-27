using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NEA_prototype
{
    internal class Geometric : ParentProbabilityClass
    {
        public Geometric(double probability) : base()
        {
            UpdateVariables(probability);
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
                        UpdateVariables(GetNewProbability());
                        MainMenuChoices();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 2)
                    {
                        Console.Clear();
                        Console.Write($"E(x) : {GetEX()}");
                        Console.ReadKey(true);
                        MainMenuChoices();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 3)
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
        public void UpdateVariables(double probability)
        {
            this.probability = probability;
            expectedvalue = Math.Pow(probability, -1);
            varience = (1 - probability) * Math.Pow(probability, -2);
        }
        protected void MainMenuChoices()
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("  Change Probability");
            Console.WriteLine("  Expected Value");
            Console.WriteLine("  Varience");
            Console.WriteLine("  Exit");
        }

        public double GetNewProbability()
        {
            Console.Clear();
            Console.Write("Probability : ");
            return double.Parse(Console.ReadLine());
        }
    }
}