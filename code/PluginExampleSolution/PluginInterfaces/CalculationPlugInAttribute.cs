namespace PluginInterfaces
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CalculationPlugInAttribute:Attribute
    {
        public string Description { get; private set; }

        public CalculationPlugInAttribute(string description) 
        {
            this.Description = description;
        }
    }
}
