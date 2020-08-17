namespace AppWorldAgent.Services.DataAccess.Identity
{
    using AppWorldAgent.Infrastructure;
    using AppWorldAgent.Infrastructure.Exceptions;
    using AppWorldAgent.Infrastructure.Extensions;
    using AppWorldAgent.Infrastructure.Globalization;
    using AppWorldAgent.Infrastructure.Services.RequestProvider;
    using AppWorldAgent.Services.Criteria;
    using AppWorldAgent.Services.Entity;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class IdentityService : IIdentityService
    {
        private readonly IRequestProvider _requestProvider;
        public IdentityService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<UserProfileModel> SignInAsync(UserCredentialCriteria model)
        {
            UserProfileModel resultModel;
            try
            {
                await Task.Delay(20);

                if (model.UserName.Equals("WorldAgent") && model.Password.Equals("WorldAgent"))
                {
                    resultModel = new UserProfileModel
                    {
                        AccessToken = Guid.NewGuid().ToString(),
                        UserName = "World Agent",
                        UserLastName = "World Agent",
                        UserType = "Admin",
                        URLService = GlobalSetting.DefaultURLService,
                        Successful = true,
                        Errors = new System.Collections.Generic.List<string>()
                    };
                }
                else
                {
                    resultModel = new UserProfileModel();
                }

                //var uri = new Uri(string.Format(GlobalSetting.DefaultUrlBase, string.Empty));
                //resultModel = await _requestProvider.PutAsync<UserProfileModel, UserCredentialCriteria>(uri, model, string.Empty);
            }
            catch (Exception ex)
            {
                WebException webException = ex.FindInnerException<WebException>();
                if (webException != null)
                {
                    resultModel = new UserProfileModel();
                    resultModel.Errors.Add(DisplayInformation.WebExceptionMessage);
                }
                else
                {
                    HttpRequestExceptionEx httpRequestException = ex.FindInnerException<HttpRequestExceptionEx>();
                    if (httpRequestException != null)
                        resultModel = JsonConvert.DeserializeObject<UserProfileModel>(httpRequestException.Message);
                    else
                        throw ex;
                }
            }
            return resultModel;
        }
    }
}
