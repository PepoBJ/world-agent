namespace AppWorldAgent.Services.DataAccess.Identity
{
    using AppWorldAgent.Infrastructure;
    using AppWorldAgent.Infrastructure.Exceptions;
    using AppWorldAgent.Infrastructure.Extensions;
    using AppWorldAgent.Infrastructure.Globalization;
    using AppWorldAgent.Infrastructure.Models.User;
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

        public async Task<UserToken> SignInAsync(UserCredentialCriteria model)
        {
            UserToken resultModel;
            try
            {
                var uri = new Uri($"{GlobalSetting.DefaultUrlBase}/api/auth");
                resultModel = await _requestProvider.PostAsync<UserToken, UserCredentialCriteria>(uri, model, string.Empty);
            }
            catch (Exception ex)
            {
                WebException webException = ex.FindInnerException<WebException>();
                if (webException != null)
                {
                    resultModel = new UserToken();
                    //resultModel.Errors.Add(DisplayInformation.WebExceptionMessage);
                }
                else
                {
                    HttpRequestExceptionEx httpRequestException = ex.FindInnerException<HttpRequestExceptionEx>();
                    if (httpRequestException != null)
                        resultModel = JsonConvert.DeserializeObject<UserToken>(httpRequestException.Message);
                    else
                        throw ex;
                }
            }
            return resultModel;
        }

        public async Task<UserProfileModel> RegisterAsync(RegisterUserCriteria model)
        {
            UserProfileModel resultModel;
            try
            {
                var uri = new Uri($"{GlobalSetting.DefaultUrlBase}/api/User");
                resultModel = await _requestProvider.PostAsync<UserProfileModel, RegisterUserCriteria>(uri, model, null);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                resultModel = new UserProfileModel();
            }
            return resultModel;
        }
    }
}
