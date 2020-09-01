using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.VaultManager
{
    public class GetVaultKeys
    {

        private readonly IConfiguration _config;

        public GetVaultKeys(IConfiguration config)
        {
            _config = config;
        }
        public string getToken()
        {
            return _config.GetValue<string>("token");
        }
        public string GetvaultUri()
        {
            return _config.GetValue<string>("vaultUri");
        }
        public string GetsecretPathConnection()
        {
            return _config.GetValue<string>("secretPathConnection");
        }
        public string GetsecretPathAppSettings()
        {
            return _config.GetValue<string>("secretPathAppSettings");
        }
        public int GetrefreshIntervalHours()
        {
            return _config.GetValue<int>("refreshIntervalHours");
        }

    }
}
