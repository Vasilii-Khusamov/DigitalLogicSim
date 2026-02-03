using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using DigitalLogicSim.Components.BasicComponents;

namespace DigitalLogicSim.Components.CustomComponents.LogicGates
{
    internal class Xor
    {
        public static List<LogicComponent> Create(string name, string inputA, string inputB)
        {
            List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Nand.Create($"{name}.nand1", inputA, inputB));
            components.AddRange(Nand.Create($"{name}.nandA", inputA, $"{name}.nand1.out"));
            components.AddRange(Nand.Create($"{name}.nandB", inputB, $"{name}.nand1.out"));
            components.AddRange(Nand.Create($"{name}", $"{name}.nandA.out", $"{name}.nandB.out"));
            return components;
        }
    }
}
