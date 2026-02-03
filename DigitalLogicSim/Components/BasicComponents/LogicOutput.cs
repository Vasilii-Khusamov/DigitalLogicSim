using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.BasicComponents
{
    internal class LogicOutput : LogicComponent
    {
        public LogicOutput(string name, string input)
        {
            Name = name;
            InputNames = [input];
            OutputNames = []; // LogicOutput has no outputs.
            OutputState = [new Signal(0)]; // OutputState is not used for output component, but initialized to avoid null reference.
        }
        public static List<LogicComponent> Create(string name, string input)
        {
            return new List<LogicComponent>([new LogicOutput(name, input)]);
        }
        public override void Initialize(LogicCircuit logicCircuit)
        {
            circuit = logicCircuit;
            if (InputNames == null) throw new Exception("InputNames is null in LogicBuffer component: " + Name);
            if (circuit == null) throw new Exception("circuit is null for this component: " + Name);
            InputState = new Signal[InputNames.Length];
            for (int i = 0; i < InputNames.Length; i++)
            {
                string inputName = InputNames[i];
                Signal inputSignal = circuit.FindOutputByName(inputName);
                InputState[i] = inputSignal;
            }
        }
        public override void Evaluate()
        {
            // LogicOutput does not need to do anything during evaluation.
            // It simply holds a reference to the input signal.
        }
        public Signal GetSignal()
        {
            if (InputState == null) throw new Exception("InputState is null in LogicOutput component: " + Name);
            Signal inputSignal = InputState[0];
            return inputSignal;
        }
    }
}
