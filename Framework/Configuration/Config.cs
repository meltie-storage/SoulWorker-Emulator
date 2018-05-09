// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.IO;
using System.Text;

using SoulWorker.Framework.Logging;

namespace SoulWorker.Framework.Configuration
{
    public class Config
    {
        readonly string[] ConfigContent;
        public string ConfigFile { get; set; }

        public Config(string config)
        {
            ConfigFile = config;

            if (!File.Exists(config))
            {
                Log.Message(LogType.Error, "{0} doesn't exist!", config);
                Environment.Exit(0);
            }
            else
                ConfigContent = File.ReadAllLines(config, Encoding.UTF8);
        }

        public T Read<T>(string name, T value, bool hex = false)
        {
            string nameValue = null;
            T trueValue = (T)Convert.ChangeType(value, typeof(T));
            int lineCounter = 0;

            try
            {
                foreach (var option in ConfigContent)
                {
                    var configOption = option.Split(new char[] { '=' }, StringSplitOptions.None);
                    if (configOption[0].StartsWith(name, StringComparison.Ordinal))
                        if (configOption[1].Trim() == "")
                            nameValue = value.ToString();
                        else
                            nameValue = configOption[1].Replace("\"", "").Trim();

                    lineCounter++;
                }
            }
            catch
            {
                Log.Message(LogType.Error, "Error in {0} in line {1}", ConfigFile, lineCounter);
            }

            if (hex)
                return (T)Convert.ChangeType(Convert.ToInt32(nameValue, 16), typeof(T));

            if (typeof(T) == typeof(bool))
            {
                if (nameValue == "0")
                    return (T)Convert.ChangeType(false, typeof(T));
                else if (nameValue == "1")
                    return (T)Convert.ChangeType(true, typeof(T));
                else
                {
                    Log.Message(LogType.Error, "Error in {0} in line {1}", ConfigFile, lineCounter);
                    Log.Message(LogType.Error, "Use default value for boolean config option: {0}. Default: {1}", name, value);
                }
            }

            return (T)Convert.ChangeType(nameValue, typeof(T));
        }
    }
}
