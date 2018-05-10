// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;

namespace SoulWorker.Framework.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class CommandAttribute : Attribute
    {
        public string Command { get; set; }
        public string Description { get; set; }

        public CommandAttribute(string command, string description)
        {
            Command = command;
            Description = description;
        }
    }
}
