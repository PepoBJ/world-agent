/*******************************************************************************
 **     Visual Studio 2019 Developer Filio Carrasco Sauñe
 **     Copyright (c) 2020 Logaware Corporation
 *******************************************************************************/
namespace AppWorldAgent.Infrastructure.Exceptions
{
    using AppWorldAgent.Infrastructure.Extensions;
    using AppWorldAgent.Infrastructure.Globalization;
    using AppWorldAgent.Infrastructure.Models.Result;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class ServiceResolveException
    {
        /// <summary>
        /// ResolveException
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static ResultModel ResolveException(this Exception ex)
        {
            ResultModel resultModel;

            AuthenticationException authenticationException = ex.FindInnerException<AuthenticationException>();
            if (authenticationException != null)
            {
                resultModel = JsonConvert.DeserializeObject<ResultModel>(authenticationException.Message);
                resultModel.Logout = true;
            }
            else
            {
                WebException webException = ex.FindInnerException<WebException>();
                if (webException != null)
                {
                    resultModel = new ResultModel();
                    resultModel.Errors.Add(DisplayInformation.WebExceptionMessage);
                }
                else
                {
                    HttpRequestExceptionEx httpRequestException = ex.FindInnerException<HttpRequestExceptionEx>();
                    if (httpRequestException != null)
                        resultModel = JsonConvert.DeserializeObject<ResultModel>(httpRequestException.Message);
                    else
                    {
                        HttpRequestException _HttpRequestException = ex.FindInnerException<HttpRequestException>();
                        if (_HttpRequestException != null)
                        {
                            resultModel = new ResultModel();
                            resultModel.Errors.Add(_HttpRequestException.Message);
                        }
                        else
                        {
                            TaskCanceledException _TaskCanceledException = ex.FindInnerException<TaskCanceledException>();
                            if (_TaskCanceledException != null)
                            {
                                resultModel = new ResultModel();
                                resultModel.Errors.Add(_TaskCanceledException.Message);
                            }
                            else
                            {
                                resultModel = new ResultModel();
                                resultModel.Errors.Add(ex.Message);
                            }
                        }
                    }
                }
            }
            return resultModel;
        }

        /// <summary>
        /// ResolveException<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static ResultModel<T> ResolveException<T>(this Exception ex) where T : class
        {
            ResultModel<T> resultModel;

            AuthenticationException authenticationException = ex.FindInnerException<AuthenticationException>();
            if (authenticationException != null)
            {
                resultModel = JsonConvert.DeserializeObject<ResultModel<T>>(authenticationException.Message);
                resultModel.Logout = true;
            }
            else
            {
                WebException webException = ex.FindInnerException<WebException>();
                if (webException != null)
                {
                    resultModel = new ResultModel<T>();
                    resultModel.Errors.Add(DisplayInformation.WebExceptionMessage);
                }
                else
                {
                    HttpRequestExceptionEx httpRequestException = ex.FindInnerException<HttpRequestExceptionEx>();
                    if (httpRequestException != null)
                        resultModel = JsonConvert.DeserializeObject<ResultModel<T>>(httpRequestException.Message);
                    else
                    {
                        HttpRequestException _HttpRequestException = ex.FindInnerException<HttpRequestException>();
                        if (_HttpRequestException != null)
                        {
                            resultModel = new ResultModel<T>();
                            resultModel.Errors.Add(_HttpRequestException.Message);
                        }
                        else
                        {
                            TaskCanceledException _TaskCanceledException = ex.FindInnerException<TaskCanceledException>();
                            if (_TaskCanceledException != null)
                            {
                                resultModel = new ResultModel<T>();
                                resultModel.Errors.Add(_TaskCanceledException.Message);
                            }
                            else
                            {
                                resultModel = new ResultModel<T>();
                                resultModel.Errors.Add(ex.Message);
                            }
                        }
                    }
                }
            }
            return resultModel;
        }
    }
}
