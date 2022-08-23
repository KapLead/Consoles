using System;

namespace Consoles
{
    public partial class Consolas
    {
        /// <summary> Максимальное кол-во символов в строке </summary>
        public static int MaxWidth { get; private set; } = Console.WindowWidth;
        
        /// <summary> Максимальное кол-во строк в консоли </summary>
        public static int MaxHeight { get; private set; } = Console.WindowHeight;


        /// <summary> Усстановка параметров окна </summary>
        /// <param name="width">кол-во символов в строке</param>
        /// <param name="height">кол-во строк</param>
        /// <param name="noresize">запрет изменения размеров окна консоли</param>
        public static void SetupScreen(int width=120, int height=30,bool noresize=false)
        {
            // размеры окна
            Console.BufferWidth = Console.WindowWidth = MaxWidth = width;
            Console.BufferHeight = Console.WindowHeight = MaxHeight = height;
            if (noresize && GetConsoleWindow() != IntPtr.Zero)
                NoResizeConsole();
        }

        /// <summary> Запрет изменения размеров окна (операция необратима) </summary>
        private static void NoResizeConsole()
        {
            // запретить изменять размер
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            if (handle != IntPtr.Zero)
            {
                // удаление привязки к системным кнопкам окна
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
        }
    }
}
