namespace AppWorldAgent.Models
{
    public enum MenuItemType
    {
        ProfileView,
        RegisterView,
        SettingsView,
        SelectTestViewModel,
        UrlLogaware
    }

    public class MasterDetailModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public MenuItemType Id { get; set; }
        /// <summary>
        /// Gets or sets Icon
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }

        #endregion
    }
}
