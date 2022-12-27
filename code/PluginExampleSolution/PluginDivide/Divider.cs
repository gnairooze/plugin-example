using PluginInterfaces;

namespace PluginDivide
{
    [CalculationPlugIn("This plug-in will divide two numbers")]
    public class Divider : ICalculator
    {
        public int Calculate(int a, int b)
        {
            return a / b;
        }

        public char GetSymbol()
        {
            return '/';
        }
    }
}