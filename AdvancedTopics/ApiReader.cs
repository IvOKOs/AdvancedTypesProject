using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTopics
{
    public interface IApiReader
    {
        Task<string> GetJsonAsync(string baseUrl,string url);
    }

    public class ApiReader : IApiReader
    {
        private IUserInteraction _userInteraction;

        public ApiReader(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        public async Task<string> GetJsonAsync(string baseUrl, string url)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                _userInteraction.ShowMessage("Cannot fetch data. " +  ex.Message);
            }
            catch(UriFormatException ex)
            {
                _userInteraction.ShowMessage($"Invalid url: {baseUrl}" + ex.Message);
            }
            return "";
        }
    }
}
