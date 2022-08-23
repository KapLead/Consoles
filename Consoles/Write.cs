using System;
using System.Linq;
using System.Xml.Linq;

namespace Consoles
{
    public partial class Consolas
    {
        public static void Write(string str) => Write(str, X, Y, Fore, Back);
        public static void Write(string str, int x, int y) => Write(str, x, y, Fore, Back);
        public static void Write(string str, ConsoleColor Fore, ConsoleColor Back) => Write(str, X, Y, Fore, Back);
        public static void Write(string str, int x, int y, ConsoleColor Fore, ConsoleColor Back)
        {
            Set(x,y);
            Set(Fore,Back);
            Original.Write(str,x,y,Fore,Back);
            Original.DrawRectangle(x,y,x+str.Length,1);
        }

        public static void WriteMagic(string s)
        {
            // [#M1,1] курсок в указанные координаты
            // [#B1] фон цветом 1  
            // [#F1] цветом символов 1  

            var t = s.Split(new[] {"[", "]"}, StringSplitOptions.RemoveEmptyEntries);
            int x = 0, y = 0;
            ConsoleColor _b=Console.BackgroundColor, _f=Console.ForegroundColor;
            foreach (string i in t)
            {
                if (i.Length>1 && i.StartsWith("#"))
                {
                    switch (i[1])
                    {
                        case 'm':
                        case 'M':
                            var coord = i.Substring(2).Split(',').Select(int.Parse).ToArray();
                            if (coord.Length == 2)
                            {
                                x = coord[0];
                                y = coord[1];
                            }
                            break;
                        case 'b':
                        case 'B':
                            if (int.TryParse(i.Substring(2), out int b))
                                _b = (ConsoleColor)(Enum.GetValues(typeof(ConsoleColor)).GetValue(b));
                            break;
                        case 'f':
                        case 'F':
                            if (int.TryParse(i.Substring(2), out int f))
                                _f = (ConsoleColor)(Enum.GetValues(typeof(ConsoleColor)).GetValue(f));
                            break;
                    }
                }
                else
                {
                    Original.Write(i,x,y,_f,_b);
                    Original.DrawRectangle(x,y,i.Length,1);
                    x += i.Length;
                }
            }
        }
    }
}
