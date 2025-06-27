using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_prototype
{
    internal class Pearsons
    {
        protected int TotalInputs = 0;
        protected double[,] DataSet;
        protected double SumX, SumY, SumXX, SumXY, SumYY;
        protected double interceptYX, gradientYX, interceptXY, gradientXY;
        public Pearsons()
        {
            GenerateTable();
            CalculateTotals();
        }
        public Pearsons(double SumX, double SumY, double SumXX, double SumXY, double SumYY, int TotalInputs)
        {
            this.SumX = SumX;
            this.SumY = SumY;
            this.SumXX = SumXX;
            this.SumXY = SumXY;
            this.SumYY = SumYY;
            this.TotalInputs = TotalInputs;
        }
        public Pearsons(double[,] xy)
        {
            TotalInputs = xy.GetLength(0);
            DataSet = xy;
            CalculateTotals();
        }
        public void Menu()
        {
            bool exit = false;
            int CurrentOptionMainMenu = 1;
            PearsonsMenuOptions();
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
                        Console.Clear();
                        GenerateTable();
                        PearsonsChartForm Chart = new PearsonsChartForm(DataSet);
                        Chart.ShowDialog();
                        PearsonsMenuOptions();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 2)
                    {
                        Console.Clear();
                        PearsonsChartForm Chart = new PearsonsChartForm(DataSet);
                        Chart.ShowDialog();
                        PearsonsMenuOptions();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else if (CurrentOptionMainMenu == 3)
                    {
                        Console.Clear();
                        Console.WriteLine($"Y on X : {GetLineYonX()}");
                        Console.WriteLine($"X on Y : {GetLineXonY()}");
                        Console.ReadKey(true);
                        PearsonsMenuOptions();
                        Console.CursorLeft = 0;
                        Console.CursorTop = CurrentOptionMainMenu;
                        Console.Write(">");
                    }
                    else exit = true;
                }
            } while (exit != true);

        }
        protected void PearsonsMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("PMCC Menu");
            Console.WriteLine("  Generate and View New points");
            Console.WriteLine("  View Current points");
            Console.WriteLine("  Calculate a Line of Best fit");
            Console.WriteLine("  Exit");
        }
        protected void GenerateTable()
        {
            Random random = new Random(0);
            TotalInputs = random.Next(3, 60);
            DataSet = new double[TotalInputs, 2];
            for(int i = 0; i < TotalInputs; i++)
            {
                DataSet[i, 0] = random.Next(0, 20);
                DataSet[i, 1] = random.Next(0, 20) + random.NextDouble();
            }
        }
        protected string GetLineYonX()
        {
            if (interceptYX >= 0)
                return $"the Equation of the line is: y = {gradientYX}x + {interceptYX}";
            else
                return $"the Equation of the line is: y = {gradientYX}x - {Math.Abs(interceptYX)}";
        }
        protected string GetLineXonY()
        {
            if (interceptYX >= 0)
                return $"the Equation of the line is: y = {gradientXY}x + {interceptXY}";
            else
                return $"the Equation of the line is: y = {gradientXY}x - {Math.Abs(interceptXY)}";
        }
        protected void CalculateTotals()
        {
            for (int i = 0; i < TotalInputs; i++)
            {
                SumX += DataSet[i, 0];
                SumY += DataSet[i, 1];
                SumXX += Math.Pow(DataSet[i, 0], 2);
                SumXY += DataSet[i, 0] * DataSet[i, 1];
                SumYY += Math.Pow(DataSet[i, 1], 2);
            }
        }
        protected void CalculateLineYonX()
        {
            gradientYX = ((TotalInputs * SumXY) - (SumX * SumY)) / ((TotalInputs * SumXX) - Math.Pow(SumX, 2));
            interceptYX = (SumY - (gradientYX * SumX)) / TotalInputs;
        }
        protected void CalculateLineXonY()
        {
            gradientXY = ((TotalInputs * SumXY) - (SumX * SumY)) / ((TotalInputs * SumYY) - Math.Pow(SumY, 2));
            interceptXY = (SumX - (gradientXY * SumY)) /TotalInputs;
        }
        public double[,] GetDataSet()
        {
            return DataSet;
        }

    }
}
