// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulWorker.Shared.Database
{
    class DatabaseSettings
    {
        public string Host;
        public int  Port;
        public string Database;
        public string Username;
        public string Password;

        public string CharSet = "utf8";
    }
}
