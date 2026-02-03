using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.BasicComponents
{
    internal class WordPacker : LogicComponent
    {
        public WordPacker(string name, string[] inputs)
        {
            Name = name;
            InputNames = inputs;
            InputState = new Signal[inputs.Length];
            OutputNames = ["out"];
            OutputState = [new Signal(inputs.Length)];
            for (int i = 0; i < inputs.Length; i++)
            {
                InputState[i] = new Signal(1);
            }
        }
        public static LogicComponent Create(string name, string[] inputs)
        {
            return new WordPacker(name, inputs);
        }
        public override void Initialize(LogicCircuit logicCircuit)
        {
            if (InputState == null) throw new Exception("Error: InputState is null for component: " + Name);
            if (InputNames == null) throw new Exception("Error: InputNames is null for component: " + Name);
            circuit = logicCircuit;
            for (int i = 0; i < InputNames.Length; i++)
            {
                InputState[i] = circuit.FindOutputByName(InputNames[i]);
            }
        }
        public override void Evaluate()
        {
            if (InputState == null) throw new Exception("Error: InputState is null for component: " + Name);
            if (OutputState == null) throw new Exception("Error: OutputState is null for component: " + Name);
            
            for (int i = 0; i < InputState.Length; i++)
            {
                OutputState[0].state[i] = InputState[i].state[0];
            }
        }
    }
}
