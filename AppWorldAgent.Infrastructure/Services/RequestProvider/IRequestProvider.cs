namespace AppWorldAgent.Infrastructure.Services.RequestProvider
{
    using System;
    using System.Threading.Tasks;

    public interface IRequestProvider 
    {
        Task<TResult> GetAsync<TResult>(Uri uri, string token = "");

        Task<TResult> PutAsync<TResult>(Uri uri, TResult data, string token = "", string header = "");

        Task<TResult> PutAsync<TResult, TModel>(Uri uri, TModel data, string token = "", string header = "");

        Task<TResult> PostAsync<TResult>(Uri uri, TResult data, string token = "", string header = "");

        Task<TResult> PostAsync<TResult>(Uri uri, string data, string token = "", string header = "");

        Task<TResult> PostAsync<TResult, TData>(Uri uri, TData data, string token, string header = "");

        Task<TResult> PatchAsync<TResult, TModel>(Uri uri, TModel data, string token = "", string header = "");

        //Task DeleteAsync(string uri, string token = "");
    }
}
