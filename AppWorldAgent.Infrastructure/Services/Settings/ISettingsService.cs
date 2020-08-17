namespace AppWorldAgent.Infrastructure.Services.Settings
{
    using System;
    using System.Threading.Tasks;

    public interface ISettingsService
    {
        string AccessToken { get; set; }
        string UserName { get; set; }
        string UserLastName { get; set; }
        string UserType { get; set; }
        string UrlBase { get; set; }
        bool UseMocks { get; set; }

        long GetValueOrDefault(string key, long defaultValue);
        bool GetValueOrDefault(string key, bool defaultValue);
        byte[] GetValueOrDefault(string key, byte[] defaultValue);
        string GetValueOrDefault(string key, string defaultValue);
        DateTime GetValueOrDefault(string key, DateTime defaultValue);

        Task AddOrUpdateValue(string key, long value);
        Task AddOrUpdateValue(string key, bool value);
        Task AddOrUpdateValue(string key, byte[] value);
        Task AddOrUpdateValue(string key, string value);
        Task AddOrUpdateValue(string key, DateTime value);
    }
}
