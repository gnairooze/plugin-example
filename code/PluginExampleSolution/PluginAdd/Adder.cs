using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAdd
{
    [CalculationPlugIn("This plug-in will sum two numbers")]
    public class Adder : ICalculator
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }

        public char GetSymbol()
        {
            return '+';
        }
    }
}
