using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLogicSim.Components.CustomComponents.LogicGates;

namespace DigitalLogicSim.Components.CustomComponents.Memory
{
    internal class Register
    {
        public static List<LogicComponent> Create(string name, string data, int dataWidth, string store, string clock)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Pulse.Create($"{name}.pulse", clock));
            components.AddRange(And.Create($"{name}.and", store, $"{name}.pulse.out"));
            for (int i = 0; i < dataWidth; i++)
            {
                components.AddRange(DLatch.Create($"{name}[{i}]", data + $"[{i}].out", $"{name}.and.out"));
            }
            return components;
        }
    }
}
