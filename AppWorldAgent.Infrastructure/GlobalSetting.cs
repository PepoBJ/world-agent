namespace AppWorldAgent.Infrastructure
{
    public class GlobalSetting
    {
        #region Const Properties
        public const string DefaultURLService = "https://www.AppWorldAgent.com/"; // i.e.: "http://YOUR_IP" or "http://YOUR_DNS_NAME"
        public const string DefaultUrlBase = "https://www.AppWorldAgent.com/"; 
        public const string UrlWeb = "https://www.google.com/"; 
        #endregion

        #region Properties
        private string _baseEndpoint;
        /// <summary>
        /// UrlBaseLogawareDefault
        /// </summary>
        public string UrlBaseDefault { get; set; }

        /// <summary>
        /// BaseEndpoint
        /// </summary>
        public string BaseEndpoint
        {
            get { return _baseEndpoint; }
            set
            {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }
        #endregion

        #region Instance
        /// <summary>
        /// Instance
        /// </summary>
        public static GlobalSetting Instance { get; } = new GlobalSetting();

        #endregion

        #region Constructor

        public GlobalSetting()
        {
            BaseEndpoint = DefaultURLService;
        }

        #endregion

        #region Methods
        private void UpdateEndpoint(string baseEndpoint)
        {
            var identityBaseEndpoint = $"{baseEndpoint}/api";
        }
        #endregion
    }
}
