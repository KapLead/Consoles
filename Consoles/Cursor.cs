using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consoles
{
    public partial class Consolas
    {
        /// <summary> Текущие координаты курсора по Х </summary>
        public static int X
        {
            get => Console.CursorLeft;
            set => Console.CursorLeft = value;
        }

        /// <summary> Текущие координаты курсора по У </summary>
        public static int Y
        {
            get => Console.CursorTop;
            set => Console.CursorTop = value;
        }

        public static bool CursorVisible
        {
            get => Console.CursorVisible;
            set => Console.CursorVisible = value;
        }
        /// <summary> Установить курсор в указанных координатах </summary>
        public static void Set(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
