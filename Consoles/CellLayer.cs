using System;

namespace Consoles
{
    public struct CellLayer
    {
        public char Char { get; set; }
        public ConsoleColor Fore { get; set; }
        public ConsoleColor Back { get; set; }

        public override string ToString()
        {
            return $"{Char}";
        }
    }
}
