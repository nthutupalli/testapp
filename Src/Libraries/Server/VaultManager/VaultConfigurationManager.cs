using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace Server.VaultManager
{
    public sealed class VaultConfigurationManager
    {

       
        static readonly object LockObject = new object();
        private static readonly string VaultUriValue = ConfigurationManager.AppSettings["vaultUri"];
        private static readonly string TokenValue = ConfigurationManager.AppSettings["token"];
        private static readonly string secretPathConnection = ConfigurationManager.AppSettings["secretPathConnection"];
        private static readonly string secretPathAppSettings = ConfigurationManager.AppSettings["secretPathAppSettings"];
        private static readonly int RefreshIntervalHours = int.Parse(ConfigurationManager.AppSettings["refreshIntervalHours"]);


        public static DateTime RefreshCollectionDate { get; set; }
        /// <summary>
        /// There really should only be one instance of the manager running. 
        /// </summary>
        static VaultConfigurationManager _instanceConnection;

        /// <summary>
        /// The Vault client implementation.
        /// </summary>
        private static Dictionary<string, dynamic> connectionStrings = null;


        public static VaultConfigurationManager InstanceConnection
        {
            get
            {
                lock (LockObject)
                {
                    if (_instanceConnection == null)
                        _instanceConnection = new VaultConfigurationManager();

                    return _instanceConnection;
                }
            }
        }

        public Dictionary<string, dynamic> ConnectionString
        {
            get
            {
                if (connectionStrings == null || RefreshCollectionDate <= DateTime.Now)
                    connectionStrings = InvokeVaultSecrets(secretPathConnection);
                return connectionStrings;
            }
        }

        static VaultConfigurationManager _instanceAppSetting;

        /// <summary>
        /// The Vault client implementation.
        /// </summary>
        private static Dictionary<string, dynamic> appsettings = null;

        public static VaultConfigurationManager InstanceAppSettings
        {
            get
            {
                lock (LockObject)
                {
                    if (_instanceAppSetting == null)
                        _instanceAppSetting = new VaultConfigurationManager();

                    return _instanceAppSetting;
                }
            }
        }

        public Dictionary<string, dynamic> AppSettings
        {
            get
            {
                if (appsettings == null || RefreshCollectionDate <= DateTime.Now)
                    appsettings = InvokeVaultSecrets(secretPathAppSettings);
                return appsettings;
            }
        }

        private static Dictionary<string, object> InvokeVaultSecrets(string secretPath)
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
