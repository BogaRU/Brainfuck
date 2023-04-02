using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace func.brainfuck
{
    public class BrainfuckBasicCommands
    {
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
        {
            vm.RegisterCommand('.', b => { write((char)b.Memory[b.MemoryPointer]); });
            vm.RegisterCommand('+', b => { b.Memory[b.MemoryPointer] = (byte)((b.Memory[b.MemoryPointer] + 1) % 256); });
            vm.RegisterCommand('-', b => { b.Memory[b.MemoryPointer] = (byte)((b.Memory[b.MemoryPointer] - 1) % 256 + (b.Memory[b.MemoryPointer] == 0 ? 256 : 0)); });
            vm.RegisterCommand(',', b => { b.Memory[b.MemoryPointer] = (byte)read(); });
            vm.RegisterCommand('>', b => { b.MemoryPointer = (b.MemoryPointer + 1) % b.Memory.Length; });
            vm.RegisterCommand('<', b => { b.MemoryPointer = (b.MemoryPointer - 1) % b.Memory.Length + (b.MemoryPointer == 0 ? b.Memory.Length : 0); });
            for (byte i = 48; i < 58; i++)
            {
                var j = i;
                vm.RegisterCommand((char)j, b => { b.Memory[b.MemoryPointer] = j; });
            }
            for (byte i = 65; i < 91; i++)
            {
                var j = i;
                vm.RegisterCommand((char)j, b => { b.Memory[b.MemoryPointer] = j; });
            }
            for (byte i = 97; i < 123; i++)
            {
                var j = i;
                vm.RegisterCommand((char)j, b => { b.Memory[b.MemoryPointer] = j; });
            }
        }
    }
}