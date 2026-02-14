using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Simulation
{
    internal class NandGate : LogicComponent
    {
        private Wire _inputA;
        private Wire _inputB;
        private Wire _output;
        public NandGate(Wire inputA, Wire inputB, Wire output)
        {
            _inputB = inputB;
            _inputA = inputA;
            _output = output;
        }
        void LogicComponent.Update()
        { 
            _output.Value = !(_inputA.Value && _inputB.Value);
        }
    }
}
