using System;

namespace Consoles
{
    public partial class Consolas
    {

        /// <summary> Установить цвет фона </summary>
        private static ConsoleColor Back
        {
            get => ConsoleColor.Black;
            set => Console.BackgroundColor = value;
        }


        /// <summary> Установить цвет шрифта </summary>
        private static ConsoleColor Fore
        {
            get => ConsoleColor.White;
            set => Console.ForegroundColor = value;
        }

        /// <summary> Установить текущие цвета </summary>
        /// <param name="back"> Цвет фона </param>
        /// <param name="fore"> цвет шрифта </param>
        public static void Set(ConsoleColor back, ConsoleColor fore)
        {
            Back = back;
            Fore = fore;
        }
    }
}
