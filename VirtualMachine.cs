using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }

		public Dictionary<char, Action<IVirtualMachine>> instructions = new Dictionary<char, Action<IVirtualMachine>>();

		public VirtualMachine(string program = "", int memorySize = 30000)
		{
			InstructionPointer = 0;
			MemoryPointer = 0;
			Memory = new byte[memorySize];
			Instructions = program;
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			instructions[symbol] = execute;
		}

		public void Run()
		{
			for(; InstructionPointer < Instructions.Length; InstructionPointer++)
			{
				var c = Instructions[InstructionPointer];
				if (!instructions.ContainsKey(c)) continue;
				instructions[c](this);
			}
		}
	}
}