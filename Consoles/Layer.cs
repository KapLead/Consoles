using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Consoles
{
    public class Layer
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private CellLayer[,] map = null;


        public Layer()
        {
            Initialize(Console.WindowWidth, Console.WindowHeight);
        }

        /// <summary> Инициализировать слой </summary>
        public Layer Initialize(int width, int height)
        {
            map = new CellLayer[Width=width, Height=height];
            return this;
        }

        /// <summary> Очистить слой </summary>
        public Layer Clear(ConsoleColor fore, ConsoleColor back)
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    map[x,y] = new CellLayer {Back = back,Fore=fore,Char = ' '};
            return this;
        }

        /// <summary> Отрисовать в окне указанную часть содержимого буфера </summary>
        public void DrawRectangle(int left, int top, int width, int height)
        {

            for (int y = top; y < top+height; y++)
            for (int x = left; x <left+width; x++)
            {
                    Console.ForegroundColor = map[x, y].Fore;
                    Console.BackgroundColor = map[x, y].Back;
                    Console.SetCursorPosition(x,y);
                    Console.Write(map[x,y].Char);
                    //Debug.WriteLine($"{x},{y} '{map[x, y].Char}'");
            }
        }

        /// <summary> Перенести буфер на экран полностью </summary>
        public void Draw()
        {
            DrawRectangle(0,0,Width-1,Height-1);
        }

        public void Write(string str, int x, int y, ConsoleColor Fore, ConsoleColor Back)
        {
            int _x = x;
            foreach (char c in str)
            {
                if(_x>=Width) break;
                map[_x, y].Char = c;
                map[_x, y].Fore = Fore;
                map[_x++, y].Back = Back;
            }
        }
    }
}
