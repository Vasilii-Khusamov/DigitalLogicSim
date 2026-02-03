using DigitalLogicSim.Components.BasicComponents;
using System.Collections.Generic;
using System.Linq;


namespace DigitalLogicSim.Components.CustomComponents.LogicGates
{
    internal class And
    {
        public static List<LogicComponent> Create(string name, string inputA, string inputB)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Nand.Create($"{name}.nand", $"{inputA}", $"{inputB}"));
            components.AddRange(Not.Create($"{name}", $"{name}.nand.out"));
            return components;
        }
    }
}
