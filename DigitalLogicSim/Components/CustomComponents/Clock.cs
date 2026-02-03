using DigitalLogicSim.Components.CustomComponents.LogicGates;
using System.Collections.Generic;
using System.Linq;

namespace DigitalLogicSim.Components.CustomComponents
{
	internal class Clock
	{
		public static List<LogicComponent> Create(string name, int frequncy = 1)
		{
			List<LogicComponent> components = new List<LogicComponent>();
            components.AddRange(Not.Create($"{name}.delay0", $"{name}.delay{frequncy - 1}.out"));
			for (int i = 1; i < frequncy; i++)
			{
                components.AddRange(Delay.Create($"{name}.delay{i}", $"{name}.delay{i - 1}.out"));
            }
            components.AddRange(Not.Create($"{name}", $"{name}.delay{frequncy - 1}.out"));
            return components;
		}
	}
}
