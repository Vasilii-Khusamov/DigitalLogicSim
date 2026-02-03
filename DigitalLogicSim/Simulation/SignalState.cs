using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim
{
    // Represents the abstract state of a signal in the digital logic simulator.
    // like HIGH, LOW, or UNDEFINED.
    public enum SignalState
    {
        HIGH,
        LOW,
        ZERO
    }
    public class Signal
    {
        public SignalState[] state;
        public Signal(int size = 1)
        {
            state = new SignalState[size];
            for (int i = 0; i < size; i++)
            {
                state[i] = SignalState.ZERO;
            }
        }
    }
}
