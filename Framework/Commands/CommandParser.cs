// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.Globalization;
using SoulWorker.Framework.Logging;

namespace SoulWorker.Framework.Commands
{
    public class CommandParser
    {
        public static T Read<T>(string[] args, int index)
        {
            try
            {
                return (T)Convert.ChangeType(args[index], typeof(T), CultureInfo.GetCultureInfo("en-US").NumberFormat);
            }
            catch
            {
                Log.Message(LogType.Error, "Wrong arguments for the current command!!!");
            }

            return default(T);
        }
    }
}