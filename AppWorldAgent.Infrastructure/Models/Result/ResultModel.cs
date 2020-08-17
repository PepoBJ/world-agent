using AppWorldAgent.Infrastructure.Models.User;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppWorldAgent.Infrastructure.Models.Result
{
    public class ResultModel : LogoutParameter
    {
        #region Properties
        /// <summary>
        /// Gets or sets ResultList
        /// </summary>
        [JsonProperty("KEYSession")]
        public string AccessToken { get; set; }
        /// <summary>
        /// Gets or sets AccessToken
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// Gets or sets Errors
        /// </summary>
        public List<string> Errors = new List<string>();
        #endregion 

    }

    public class ResultModel<T> : ResultModel where T : class 
    {
        /// <summary>
        /// Gets or sets ResultList
        /// </summary>
        public List<T> ResultList = new List<T>();
    }
}
