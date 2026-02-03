using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLogicSim.SimulationTools
{
    internal class LogicTracer
    {
        private readonly LogicCircuit circuit;
        private List<Signal> traces;
        private List<List<SignalState[]>> readings;
        private string[] signalNames;
        public LogicTracer(LogicCircuit circuit, string[] signalNames)
        {
            this.circuit = circuit;
            traces = new List<Signal>();
            readings = new List<List<SignalState[]>>();
            this.signalNames = signalNames;
            foreach (string trace in signalNames)
            {
                Signal signalTrace = circuit.FindOutputByName(trace);
                traces.Add(signalTrace);
                readings.Add(new List<SignalState[]>());
            }
        }
        public void RecordStep()
        {
            for (int i = 0; i < traces.Count; i++)
            {
                readings[i].Add((SignalState[])traces[i].state.Clone()); // store a copy of the current state
            }
        }
        public void PrintTraces()
        {
            for (int i = 0; i < traces.Count; i++)
            {
                StringBuilder traceText = new StringBuilder();
                foreach (SignalState[] state in readings[i])
                {
                    traceText.Append(SignalToString(state));
                }
                Console.WriteLine("{0,-20}|{1}", signalNames[i], traceText.ToString());
            }
        }
        private string SignalToString(SignalState[] state)
        {
            string s = "";
            if (state.Length == 1)
            {
                switch (state[0])
                {
                    case SignalState.LOW:
                        s = "_";
                        break;
                    case SignalState.HIGH:
                        s = "#";
                        break;
                    case SignalState.ZERO:
                        s = "x";
                        break;
                }
            }
            else
            {
                s = FromSignalToInt(state).ToString();
                //for (int i = 0; i < state.Length; i++)
                //{
                //    switch (state[i])
                //    {
                //        case SignalState.LOW:
                //            s += "_";
                //            break;
                //        case SignalState.HIGH:
                //            s += "#";
                //            break;
                //        case SignalState.ZERO:
                //            s += "x";
                //            break;
                //    }
                //}
            }
            return s;
        }
        private static int FromSignalToInt(SignalState[] bits)
        {
            int value = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == SignalState.HIGH)
                    value |= (1 << i);
            }
            return value;
        }
    }
}
