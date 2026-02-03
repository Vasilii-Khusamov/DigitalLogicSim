using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.CustomComponents.LogicGates
{
    internal class Xnor
    {
        public static List<LogicComponent> Create(string name, string inputA, string inputB)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Xor.Create($"{name}.xor", inputA, inputB));
            components.AddRange(Not.Create($"{name}", $"{name}.xor.out"));
            return components;
        }
    }
}
