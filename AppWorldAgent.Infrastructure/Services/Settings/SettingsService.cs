namespace AppWorldAgent.Infrastructure.Services.Settings
{
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class SettingsService : ISettingsService
    {
        #region Setting Constants

        private const string IdAccessToken = "Id_AccessToken";
        private const string IdUserName = "Id_UserName";
        private const string IdUserLastName = "Id_UserLastName";
        private const string IdUserType = "Id_UserType";
        private const string IdUrlBase = "url_base";
        private const string IdUseMocks = "Id_UseMocks";

        private readonly string AccessTokenDefault = string.Empty;
        private readonly string UserNameDefault = string.Empty;
        private readonly string UserLastNameDefault = string.Empty;
        private readonly string UserTypeDefault = string.Empty;
        private readonly bool UseMocksDefault = true;
        private readonly string UrlBaseDefault = GlobalSetting.Instance.BaseEndpoint;

        #endregion

        #region Settings Properties
        public string AccessToken
        {
            get => GetValueOrDefault(IdAccessToken, AccessTokenDefault);
            set => AddOrUpdateValue(IdAccessToken, value);
        }

        public string UserName
        {
            get => GetValueOrDefault(IdUserName, UserNameDefault);
            set => AddOrUpdateValue(IdUserName, value);
        }
        public string UserLastName
        {
            get => GetValueOrDefault(IdUserLastName, UserLastNameDefault);
            set => AddOrUpdateValue(IdUserLastName, value);
        }
        public string UserType
        {
            get => GetValueOrDefault(IdUserType, UserTypeDefault);
            set => AddOrUpdateValue(IdUserType, value);
        }
        public string UrlBase
        {
            get => GetValueOrDefault(IdUrlBase, UrlBaseDefault);
            set => AddOrUpdateValue(IdUrlBase, value);
        }

        public bool UseMocks
        {
            get => GetValueOrDefault(IdUseMocks, UseMocksDefault);
            set => AddOrUpdateValue(IdUseMocks, value);
        }
       
        #endregion

        #region Public Methods

        public Task AddOrUpdateValue(string key, long value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, bool value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, byte[] value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, double value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, string value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, DateTime value) => AddOrUpdateValueInternal(key, value);

        public long GetValueOrDefault(string key, long defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public bool GetValueOrDefault(string key, bool defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public byte[] GetValueOrDefault(string key, byte[] defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public double GetValueOrDefault(string key, double defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public string GetValueOrDefault(string key, string defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public DateTime GetValueOrDefault(string key, DateTime defaultValue) => GetValueOrDefaultInternal(key, defaultValue);

        #endregion

        #region Internal Implementation

        async Task AddOrUpdateValueInternal<T>(string key, T value)
        {
            if (value == null)
            {
                await Remove(key);
            }

            Application.Current.Properties[key] = value;
            try
            {
                await Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to save: " + key, " Message: " + ex.Message);
            }
        }

        T GetValueOrDefaultInternal<T>(string key, T defaultValue = default(T))
        {
            object value = null;
            if (Application.Current.Properties.ContainsKey(key))
            {
                value = Application.Current.Properties[key];
            }
            return null != value ? (T)value : defaultValue;
        }

        async Task Remove(string key)
        {
            try
            {
                if (Application.Current.Properties[key] != null)
                {
                    Application.Current.Properties.Remove(key);
                    await Application.Current.SavePropertiesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove: " + key, " Message: " + ex.Message);
            }
        }

        #endregion
    }
}
