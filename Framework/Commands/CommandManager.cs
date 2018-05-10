// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

using SoulWorker.Framework.Logging;

namespace SoulWorker.Framework.Commands
{
    class CommandManager
    {
        protected static Dictionary<string, HandleCommand> CommandHandlers = new Dictionary<string, HandleCommand>();
        public delegate void HandleCommand(string[] args);

        static void DefineCommands()
        {
            var currentAsm = Assembly.GetEntryAssembly();
            foreach (var type in currentAsm.GetTypes())
            {
                foreach (var methodInfo in type.GetMethods())
                {
                    foreach (var commandAttr in methodInfo.GetCustomAttributes<CommandAttribute>())
                        if (commandAttr != null)
                            CommandHandlers[commandAttr.Command] = (HandleCommand)Delegate.CreateDelegate(typeof(HandleCommand), methodInfo);
                }
            }
        }

        static void InitCommand()
        {
            DefineCommands();

            while (true)
            {
                Thread.Sleep(5);
                Log.Message(LogType.Cmd, "Soul >> ");

                string[] line = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
                string[] args = new string[line.Length - 1];
                Array.Copy(line, 1, args, 0, line.Length - 1);

                InvokeCmdHandler(line[0].ToLower(), args);
            }
        }

        static void InvokeCmdHandler(string command, params string[] args)
        {
            if (CommandHandlers.ContainsKey(command))
                CommandHandlers[command].Invoke(args);
            else
                Log.Message(LogType.Error, "'{0}' not a valid command.", command);
        }
    }
}
