using PluginInterfaces;

namespace PluginExample
{
    public class CalculatorHost
    {
        public CalculatorHost(ICalculator calculator)
        {
            _calculator = calculator;
        }

        private ICalculator _calculator;

        public int X { get; set; }

        public int Y { get; set; }
        
        public int Calculate()
        {
            return _calculator.Calculate(this.X, this.Y);
        }

        public override string ToString()
        {
            return $"{this.X} {_calculator.GetSymbol()} {this.Y} = {_calculator.Calculate(this.X, this.Y)}";
        }
    }
}