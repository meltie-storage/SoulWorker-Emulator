// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;

namespace SoulWorkerLauncher
{
    [Serializable]
    public class SettingsKeeper
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginServiceIp { get; set; }
        public string GamePath { get; set; }

        public SettingsKeeper()
        {
            LoginServiceIp = "127.0.0.1:10000";
        }
    }
}
