// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

namespace SoulWorker.Framework.Database
{
    public class Database
    {
        public static MySqlBase Accounts = new MySqlBase();
        public static MySqlBase Characters = new MySqlBase();
        public static MySqlBase World = new MySqlBase();
    }
}
