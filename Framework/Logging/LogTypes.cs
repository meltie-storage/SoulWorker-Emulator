// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

namespace SoulWorker.Framework.Logging
{
    public enum LogType
    {
        Normal = 0x1,
        Error = 0x2,
        Dump = 0x4,
        Init = 0x8,
        DB = 0x10,
        Cmd = 0x20,
        Debug = 0x40,
        Default = 0x80
    };
}
