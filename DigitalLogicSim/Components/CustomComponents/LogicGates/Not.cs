using DigitalLogicSim.Components.BasicComponents;
using System.Collections.Generic;
using System.Linq;

namespace DigitalLogicSim.Components.CustomComponents.LogicGates
{
    internal class Not
    {
        static public List<LogicComponent> Create(string name, string input)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Nand.Create(name, input, input));
            return components;
        }
    }
}
