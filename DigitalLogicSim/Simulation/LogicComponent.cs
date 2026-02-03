using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim
{
    internal abstract class LogicComponent
    {
        public LogicCircuit? circuit;
        public string[]? InputNames;
        public Signal[]? InputState;
        public string[]? OutputNames;
        public Signal[]? OutputState;
        public string? Name;
        public abstract void Evaluate();
        public abstract void Initialize(LogicCircuit logicCircuit);
    }
}
