using DigitalLogicSim.Components.BasicComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.CustomComponents
{
    internal class Decoder
    {
        public List<LogicComponent> Create(string name, string input, int inputLength, string enable)
        {
            List<LogicComponent> components = new List<LogicComponent>();

            components.Add(WordUnpacker.Create($"{name}.unpack", input, inputLength));
            for (int i = 0;i < inputLength; i++)
            {

            }
            for (int i = 0; i < (1 << inputLength); i++) 
            { 
                
            }

            return components;
        }
        private bool[] ToBinary(int number, int length)
        {
            if (number < 0 || number >= (1 << length))
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"Number {number} cannot be represented with {length} bits.");
            }
            bool[] binary = new bool[length];
            for (int i = 0; i < length; i++)
            {
                binary[length - i - 1] = (number & (1 << i)) != 0;
            }
            return binary;
        }
    }
}
