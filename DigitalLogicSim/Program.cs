using DigitalLogicSim;
using DigitalLogicSim.Components.BasicComponents;
using DigitalLogicSim.Components.CustomComponents;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using DigitalLogicSim.Components.CustomComponents.LogicGates;
using DigitalLogicSim.Components.CustomComponents.Memory;
using DigitalLogicSim.SimulationTools;
using System.Diagnostics;

LogicCircuit components = new LogicCircuit();
components.AddComponent(Clock.Create("data[0]", 1));
components.AddComponent(Clock.Create("data[1]", 2));
components.AddComponent(Clock.Create("data[2]", 4));
components.AddComponent(Clock.Create("data[3]", 8));
components.AddComponent(WordPacker.Create("pack", ["data[0].out", "data[1].out", "data[2].out", "data[3].out"]));
components.AddComponent(WordUnpacker.Create("unpack", "pack.out", 4));
components.Initialize();

LogicTracer tracer = new LogicTracer(components, ["data[0].out", "data[1].out", "data[2].out", "data[3].out", "unpack.out0", "unpack.out1", "unpack.out2", "unpack.out3"]);

for (int i = 0; i < 16; i++)
{
    components.Step();
    tracer.RecordStep();
}
tracer.PrintTraces();