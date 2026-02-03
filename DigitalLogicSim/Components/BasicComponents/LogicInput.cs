using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.BasicComponents
{
    internal class LogicInput : LogicComponent
    {
        private SignalState state;
        public LogicInput(string name, SignalState initialState)
        {
            Name = name;
            state = initialState;
            InputNames = [];
            OutputState = [new Signal(1)];
            OutputNames = ["out"];
        }
        public static List<LogicComponent> Create(string name, SignalState initialState)
        {
            return new List<LogicComponent>([new LogicInput(name, initialState)]);
        }
        public override void Initialize(LogicCircuit logicCircuit)
        {
            circuit = logicCircuit;
        }
        public override void Evaluate()
        {
            if (OutputState == null) throw new Exception("OutputState is null in Input component: " + Name);
            OutputState[0].state = [state];
        }
        public void SetState(SignalState newState)
        {
            state = newState;
        }
    }
}
