using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Consoles
{
    public partial class Consolas
    {

        /// <summary> Получение цвета в указанных координатах </summary>
        public static ConsoleColor GetColor(int x, int y)
        {
            IntPtr hDC = Process.GetCurrentProcess().MainWindowHandle; ;
            uint pixel = GetPixel(hDC, x, y);
            ReleaseDC(IntPtr.Zero, hDC);
            byte r, g, b;
            r = (byte)(pixel & 0x000000FF);//получим состовляющие цвета
            g = (byte)((pixel & 0x0000FF00) >> 8);
            b = (byte)((pixel & 0x00FF0000) >> 16);
            return ToConsoleColor(r, g, b);
        }


        /// <summary> Конвертация RGB цвета в цвет консоли </summary>
        public static ConsoleColor ToConsoleColor(byte r, byte g, byte b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0d) return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }

        public static void WriteCharacterStrings(int start, int end,bool changeColor)
        {
            for (int ctr = start; ctr <= end; ctr++)
            {
                if (changeColor)
                    Console.BackgroundColor = (ConsoleColor)((ctr - 1) % 16);

                Console.WriteLine(new String((char)(ctr + 64), 30));
            }
        }
    }
}
