using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.Simulation
{
    internal class NandGate : LogicComponent
    {
        Wire inputA;
        Wire inputB;
        Wire output;
        void LogicComponent.Update()
        { 
            output.Value = !(inputA.Value && inputB.Value);
        }
    }
}
