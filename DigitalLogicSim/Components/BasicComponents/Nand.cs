using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Components.BasicComponents
{
	internal class Nand : LogicComponent
	{
		public Nand(string name, string inputA, string inputB)
		{
			Name = name;
			InputNames = [inputA, inputB];
			OutputNames = ["out"];
            OutputState = [new Signal(1)];
		}
		static public List<LogicComponent> Create(string name, string inputA, string inputB)
		{
			return new List<LogicComponent>([new Nand(name, inputA, inputB)]);
        }
		public override void Initialize(LogicCircuit logicCircuit)
		{
			circuit = logicCircuit;
            if (InputNames == null) throw new Exception("InputNames is null in LogicBuffer component: " + Name);
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

            SignalState A = InputState[0].state[0];
			SignalState B = InputState[1].state[0];
			if (A == SignalState.HIGH && B == SignalState.HIGH)
			{
				OutputState[0].state = [SignalState.LOW];
			} else
			{
				OutputState[0].state = [SignalState.HIGH];
            }
        }
    }
}
