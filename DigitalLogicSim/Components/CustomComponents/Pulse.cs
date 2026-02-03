using DigitalLogicSim.Components.CustomComponents.LogicGates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.CustomComponents
{
    internal class Pulse
    {
        public static List<LogicComponent> Create(string name, string input)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Delay.Create($"{name}.delay", input));
            components.AddRange(Not.Create($"{name}.not", $"{name}.delay.out"));
            components.AddRange(And.Create($"{name}", $"{name}.not.out", input));
            return components;
        }
    }
}
