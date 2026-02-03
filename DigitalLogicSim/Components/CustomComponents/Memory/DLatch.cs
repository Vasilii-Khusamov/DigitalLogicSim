using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.CustomComponents.Memory
{
    internal class DLatch
    {
        public static List<LogicComponent> Create(string name, string dataInput, string enableInput)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Mux.Create($"{name}", enableInput, $"{name}.out", dataInput));
            return components;
        }
    }
}
