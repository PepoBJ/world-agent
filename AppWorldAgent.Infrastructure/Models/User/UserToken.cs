using AppWorldAgent.Infrastructure.Models.Result;
using Newtonsoft.Json;

namespace AppWorldAgent.Infrastructure.Models.User
{
    public class UserToken : ResultModel
    {
        [JsonProperty("Token")]
        public string AccessToken { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

    }
}
