using DigitalLogicSim.Components.CustomComponents.LogicGates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.CustomComponents
{
    internal class Mux
    {
        public static List<LogicComponent> Create(string name, string switchInput, string inputA, string inputB)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Not.Create($"{name}.not", switchInput));
            components.AddRange(And.Create($"{name}.andA", inputA, $"{name}.not.out" ));
            components.AddRange(And.Create($"{name}.andB", inputB, switchInput));
            components.AddRange(Or.Create($"{name}", $"{name}.andA.out", $"{name}.andB.out"));
            return components;
        }
    }
}
