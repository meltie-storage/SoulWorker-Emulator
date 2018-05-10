// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.Text;
using DefaultConsole = System.Console;

namespace SoulWorker.Framework.Logging
{
    static public class Log
    {
        public static string ServerType { get; set; }

        static public void Message()
        {
            SetLogger(LogType.Default, "");
        }

        static public void Message(LogType type, string text, params object[] args)
        {
            SetLogger(type, text, args);
        }

        static void SetLogger(LogType type, string text, params object[] args)
        {
            DefaultConsole.OutputEncoding = Encoding.UTF8;

            switch (type)
            {
                case LogType.Normal:
                    DefaultConsole.ForegroundColor = ConsoleColor.Green;
                    text = text.Insert(0, "System: ");
                    break;
                case LogType.Error:
                    DefaultConsole.ForegroundColor = ConsoleColor.Red;
                    text = text.Insert(0, "Error: ");
                    break;
                case LogType.Dump:
                    DefaultConsole.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Init:
                    DefaultConsole.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.DB:
                    DefaultConsole.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case LogType.Cmd:
                    DefaultConsole.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogType.Debug:
                    DefaultConsole.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    DefaultConsole.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
