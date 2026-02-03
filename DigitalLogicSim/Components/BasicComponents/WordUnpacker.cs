using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.BasicComponents
{
    internal class WordUnpacker : LogicComponent
    {
        public WordUnpacker(string name, string input, int inputLength)
        {
            Name = name;
            InputNames = [input];
            InputState = [new Signal()];
            OutputNames = new string[inputLength];
            OutputState = new Signal[inputLength];
            for (int i = 0; i < inputLength; i++)
            {
                OutputNames[i] = $"out{i}";
                OutputState[i] = new Signal(1);
            }
        }
        public static LogicComponent Create(string name, string input, int InputLength)
        {
            return new WordUnpacker(name, input, InputLength);
        }
        public override void Initialize(LogicCircuit logicCircuit)
        {
            if (InputState == null) throw new Exception("Error: InputState is null for component: " + Name);
            if (InputNames == null) throw new Exception("Error: InputNames is null for component: " + Name);
            circuit = logicCircuit;
            InputState[0] = circuit.FindOutputByName(InputNames[0]);
        }
        public override void Evaluate()
        {
            if (InputState == null) throw new Exception("Error: InputState is null for component: " + Name);
            if (OutputState == null) throw new Exception("Error: OutputState is null for component: " + Name);
            for (int i = 0; i < OutputState.Length; i++)
            {
                OutputState[i].state[0] = InputState[0].state[i];
            }
        }
    }
}
