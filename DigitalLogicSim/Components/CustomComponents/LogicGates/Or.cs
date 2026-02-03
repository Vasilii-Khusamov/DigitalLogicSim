using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLogicSim.Components.BasicComponents;

namespace DigitalLogicSim.Components.CustomComponents.LogicGates
{
    internal class Or
    {
        public static List<LogicComponent> Create(string name, string inputA, string inputB)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Not.Create($"{name}.notA", inputA));
            components.AddRange(Not.Create($"{name}.notB", inputB));
            components.AddRange(Nand.Create($"{name}", $"{name}.notA.out", $"{name}.notB.out"));
            return components;
        }
    }
}
