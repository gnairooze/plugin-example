// See https://aka.ms/new-console-template for more information

//this example taken from https://www.c-sharpcorner.com/article/introduction-to-building-a-plug-in-architecture-using-C-Sharp/
//before running this example, copy divide dll and adder dll in the plugin folder

using PluginExample;

int x = 8, y = 2;

foreach (CalculatorHost calculator in CalculatorHostProvider.Calculators)
{
    calculator.X = x;
    calculator.Y = y;
    Console.WriteLine(calculator.ToString());
}


Console.ReadLine();
