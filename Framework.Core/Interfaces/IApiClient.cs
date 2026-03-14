using System.Threading.Tasks;

namespace Framework.Core.Interfaces
{
    public interface IApiClient
    {
        // Returns raw JSON string
        Task<string> GetAsync(string endpoint);

        // Automatically deserializes JSON into a C# object!
        Task<T> GetAsync<T>(string endpoint);

        // Sends a payload and deserializes the response
        Task<T> PostAsync<T>(string endpoint, object payload);
    }
}