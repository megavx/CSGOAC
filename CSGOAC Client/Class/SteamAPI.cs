using System;
using System.Collections.Generic;
using System.Text;

namespace CSGOAC_Client.Class
{
    class SteamAPI
    {
        public static void SteamGameRun(string server)
        {
            System.Diagnostics.Process.Start("steam://connect/" +server);
        }
    }
}
