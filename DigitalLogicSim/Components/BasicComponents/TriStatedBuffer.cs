using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.BasicComponents
{
    internal class TriStatedBuffer : LogicComponent
    {
        public TriStatedBuffer(string name, string input, string enable)
        {
            Name = name;
            InputNames = [input, enable];
            OutputNames = ["out"];
            OutputState = [new Signal(1)];
        }
        public static List<LogicComponent> Create(string name, string input, string enable)
        {
            return new List<LogicComponent>([new TriStatedBuffer(name, input, enable)]);
        }
        public override void Initialize(LogicCircuit logicCircuit)
        {
            circuit = logicCircuit;
            if (InputNames == null) throw new Exception("InputNames is null in TriStatedBuffer component: " + Name);
            InputState = new Signal[InputNames.Length];
            for (int i = 0; i < InputNames.Length; i++)
            {
                InputState[i] = circuit.FindOutputByName(InputNames[i]);
            }
        }
        public override void Evaluate()
        {
            if (InputNames == null) throw new Exception("InputNames is null in Nand component: " + Name);
            if (circuit == null) throw new Exception("circuit is null for this component: " + Name);
            if (InputState == null) throw new Exception("InputState is null in Nand component: " + Name);
            if (OutputState == null) throw new Exception("OutputState is null in Nand component: " + Name);

            Signal inputSignal = InputState[0];
            Signal enableSignal = InputState[1];
            if (enableSignal.state[0] == SignalState.HIGH)
            {
                OutputState[0].state = inputSignal.state;
            }
            else
            {
                OutputState[0].state = [SignalState.ZERO]; // High impedance state represented as ZERO
            }
        }
    }
}
