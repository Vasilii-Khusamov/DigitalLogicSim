using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.BasicComponents
{
    internal class LogicBuffer : LogicComponent
    {
        public LogicBuffer(string name, string outputName, string input)
        {
            Name = name;
            InputNames = [input];
            OutputState = [new Signal(1)];
            OutputNames = [outputName];
        }
        public static List<LogicComponent> Create(string name, string outputName, string input)
        {
            return new List<LogicComponent>([new LogicBuffer(name, outputName, input)]);
        }
        public override void Initialize(LogicCircuit logicCircuit)
        {
            circuit = logicCircuit;
            if (InputNames == null) throw new Exception("InputNames is null in LogicBuffer component: " + Name);
            InputState = new Signal[1];
            InputState[0] = circuit.FindOutputByName(InputNames[0]);
        }
        public override void Evaluate()
        {
            if (InputNames == null) throw new Exception("InputNames is null in LogicBuffer component: " + Name);
            if (circuit == null) throw new Exception("circuit is null for this component: " + Name);
            if (InputState == null) throw new Exception("InputState is null in LogicBuffer component: " + Name);
            if (OutputState == null) throw new Exception("OutputState is null in LogicBuffer component: " + Name);

            Signal inputSignal = InputState[0];
            OutputState[0].state = inputSignal.state;
        }
    }
}
