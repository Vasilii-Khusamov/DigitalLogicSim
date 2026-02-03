using DigitalLogicSim.Components.CustomComponents.LogicGates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.CustomComponents
{
    internal class Delay
    {
        static public List<LogicComponent> Create(string name, string input)
        {
            LogicCircuit circuit = new LogicCircuit();
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Not.Create($"{name}", $"{name}.not.out"));
            components.AddRange(Not.Create($"{name}.not", input));
            return components;
        }
    }
}
