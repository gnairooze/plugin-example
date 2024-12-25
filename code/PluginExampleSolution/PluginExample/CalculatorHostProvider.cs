using PluginInterfaces;
using System.Reflection;

//this example taken from https://www.c-sharpcorner.com/article/introduction-to-building-a-plug-in-architecture-using-C-Sharp/

namespace PluginExample
{
    public static class CalculatorHostProvider
    {
        public static List<CalculatorHost> Calculators { get; private set; }

        static CalculatorHostProvider()
        {
            Calculators= [];
            Reload();
        }

        public static void Reload()
        {
            Calculators.Clear();

            List<Assembly> plugInAssemblies = LoadPlugInAssemblies();
            List<ICalculator> plugIns = GetPlugIns(plugInAssemblies);

            foreach (ICalculator calc in plugIns)
            {
                Calculators.Add(new CalculatorHost(calc));
            }
        }

        private static List<Assembly> LoadPlugInAssemblies()
        {
            DirectoryInfo pluginPath = new(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            
            FileInfo[] files = pluginPath.GetFiles("*.dll");

            List<Assembly> plugInAssemblies = [];

            if (null != files)
            {
                foreach (FileInfo file in files)
                {
                    plugInAssemblies.Add(Assembly.LoadFile(file.FullName));
                }
            }

            return plugInAssemblies;
        }

        private static List<ICalculator> GetPlugIns(List<Assembly> assemblies)
        {
            List<Type> availableTypes = [];

            foreach (Assembly currentAssembly in assemblies)
                availableTypes.AddRange(currentAssembly.GetTypes());

            // get a list of objects that implement the ICalculator interface AND 
            // have the CalculationPlugInAttribute
            List<Type> calculatorList = availableTypes.FindAll(delegate (Type t)
            {
                List<Type> interfaceTypes = new(t.GetInterfaces());
                object[] arr = t.GetCustomAttributes(typeof(CalculationPlugInAttribute), true);
                return !(arr == null || arr.Length == 0) && interfaceTypes.Contains(typeof(ICalculator));
            });

            // convert the list of Objects to an instantiated list of ICalculators
            return calculatorList.ConvertAll<ICalculator>(delegate (Type t)
            {
                return (Activator.CreateInstance(t) as ICalculator)!;
            });
        }
    }
}
