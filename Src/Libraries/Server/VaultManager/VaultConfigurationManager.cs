/*
Copyright (C) Humana - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Firstname lastname <email@humana.com>, November 2021
*/

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace Server.VaultManager
{
    [ExcludeFromCodeCoverage]
    public class VaultConfigurationManager
    {

        private readonly IConfiguration _config;
        readonly object LockObject = new object();
        private readonly string VaultUriValue;
        private readonly string TokenValue ;
        private readonly string secretPathConnection;
        private readonly string secretPathAppSettings ;
        private readonly int RefreshIntervalHours;
        public VaultConfigurationManager(IConfiguration config)
        {
            _config = config;
            TokenValue = _config.GetValue<string>("token");
            VaultUriValue = _config.GetValue<string>("vaultUri");
            secretPathConnection = _config.GetValue<string>("secretPathConnection");
            secretPathAppSettings = _config.GetValue<string>("secretPathAppSettings");
            RefreshIntervalHours = _config.GetValue<int>("refreshIntervalHours");
        }

        public DateTime RefreshCollectionDate { get; set; }
        /// <summary>
        /// There really should only be one instance of the manager running. 
        /// </summary>
         VaultConfigurationManager _instanceConnection;

        /// <summary>
        /// The Vault client implementation.
        /// </summary>
        private Dictionary<string, dynamic> connectionStrings = null;


        public VaultConfigurationManager InstanceConnection
        {
            get
            {
                lock (LockObject)
                {
                    if (_instanceConnection == null)
                    {
                        _instanceConnection = new VaultConfigurationManager(_config);
                    }
                        

                    return _instanceConnection;
                }
            }
        }

        public Dictionary<string, dynamic> ConnectionString
        {
            get
            {
                if (connectionStrings == null || RefreshCollectionDate <= DateTime.Now)
                {
                    connectionStrings = InvokeVaultSecrets(secretPathConnection);
                }
                    
                return connectionStrings;
            }
        }

         VaultConfigurationManager _instanceAppSetting;

        /// <summary>
        /// The Vault client implementation.
        /// </summary>
        private Dictionary<string, dynamic> appsettings = null;

        public VaultConfigurationManager InstanceAppSettings
        {
            get
            {
                lock (LockObject)
                {
                    if (_instanceAppSetting == null)
                    {
                        _instanceAppSetting = new VaultConfigurationManager(_config);
                    }
                        

                    return _instanceAppSetting;
                }
            }
        }

        public Dictionary<string, dynamic> AppSettings
        {
            get
            {
                if (appsettings == null || RefreshCollectionDate <= DateTime.Now)
                {
                    appsettings = InvokeVaultSecrets(secretPathAppSettings);
                }
                    
                return appsettings;
            }
        }

        private Dictionary<string, object> InvokeVaultSecrets(string secretPath)
        {
            try
            {
                Dictionary<string, dynamic> conString = null;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                // Initialize one of the several auth methods.
                IAuthMethodInfo authMethod = new TokenAuthMethodInfo(TokenValue);

                // Initialize settings. You can also set proxies, custom delegates etc. here.
                var vaultClientSettings = new VaultClientSettings(VaultUriValue, authMethod);

                IVaultClient vaultClient = new VaultClient(vaultClientSettings);

                // Use client to read a key-value secret.
                var kv2Secret = vaultClient.V1.Secrets.KeyValue.V1.ReadSecretAsync(secretPath).GetAwaiter().GetResult();
                conString = kv2Secret.Data;
                RefreshCollectionDate = DateTime.Now.AddHours(RefreshIntervalHours);

                return conString;
            }
            catch (Exception ex)
            {
                return new Dictionary<string, dynamic>();
            }
        }
    }
}
