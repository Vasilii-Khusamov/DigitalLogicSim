using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim
{
	internal class LogicCircuit
	{
		public List<LogicComponent> components;
		public LogicCircuit()
		{
			components = new List<LogicComponent>();
        }
		public void AddComponent(LogicComponent logicComponent)
		{
			components.Add(logicComponent);
        }
		public void AddComponent(List<LogicComponent> logicCircuit)
		{
			components.AddRange(logicCircuit);
        }
		public void Initialize()
		{
			foreach (LogicComponent logicComponent in components)
			{
				logicComponent.Initialize(this);
			}
        }
        // simulates 1 tick of circuit.
        public void Step()
		{
			foreach (LogicComponent logicComponent in components) 
			{
				logicComponent.Evaluate();
			}
		}
		public Signal FindOutputByName(string outputName)
		{
            // Every character before the last '.' is the componentName.
			if (!outputName.Contains('.')) throw new Exception("Invalid output name: " + outputName);
            string componentName = outputName.Substring(0, outputName.LastIndexOf('.'));
			string signalName = outputName.Substring(outputName.LastIndexOf('.') + 1);

            List<LogicComponent> components = FindComponentsByName(componentName);
			
			Signal? outputSignal = null;
			foreach (LogicComponent component in components)
			{
				if (component.OutputNames == null) continue;
				for (int i = 0; i < component.OutputNames.Length; i++)
				{
					string name = component.OutputNames[i];
					if (name == signalName)
					{
						if (component.OutputState == null) throw new Exception("Component output state is null: " + componentName);
						outputSignal = component.OutputState[i];
					}
				}
			}
			
			if (outputSignal == null) throw new Exception("Output not found: " + outputName);
            return outputSignal; // should be reference to output signal.
        }
		public List<LogicComponent> FindComponentsByName(string name)
		{
            List<LogicComponent> component = new List<LogicComponent>();
            foreach (LogicComponent currentComponent in components)
            {
                if (currentComponent.Name == name)
                {
                    component.Add(currentComponent);
                }
            }
			if (component.Count == 0) throw new Exception("Component not found: " + name);
            return component;
        }
	}
}
