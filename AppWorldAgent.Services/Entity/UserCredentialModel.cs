using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppWorldAgent.Services.Entity
{
    public class UserCredentialModel
    {
        /// <summary>
        /// Gets or sets AccessToken
        /// </summary>
        [JsonProperty("Token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// Gets or sets CompanyLogoArray
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets KEYUser
        /// </summary>
        public string UserLastName { get; set; }
        /// <summary>
        /// Gets or sets UserType
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// Gets or sets URLService
        /// </summary>
        public string URLService { get; set; }
        /// <summary>
        /// Gets or sets Successful
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// Gets or sets Errors
        /// </summary>
        public List<string> Errors = new List<string>();
    }
}
