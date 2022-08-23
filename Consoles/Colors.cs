using System;
using System.Diagnostics;

namespace Consoles
{
    public partial class Consolas
    {

        /// <summary> Установить цвет фона </summary>
        private static ConsoleColor Back
        {
            get => _backColor;
            set => Console.BackgroundColor = _backColor= value;
        }

        private static ConsoleColor 
            _backColor=Console.BackgroundColor, 
            _foreColor=Console.ForegroundColor;


        /// <summary> Установить цвет шрифта </summary>
        private static ConsoleColor Fore
        {
            get => _foreColor;
            set => Console.ForegroundColor = _foreColor= value;
        }

        /// <summary> Установить текущие цвета </summary>
        /// <param name="back"> Цвет фона </param>
        /// <param name="fore"> цвет шрифта </param>
        public static void Set(ConsoleColor back, ConsoleColor fore)
        {
            Back = back;
            Fore = fore;
        }


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


    }
}
