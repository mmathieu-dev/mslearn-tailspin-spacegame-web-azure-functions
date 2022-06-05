using System.Text.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TailSpin.SpaceGame.Web
{
    public class LeaderboardFunctionClient : ILeaderboardServiceClient
    {
        private string _functionUrl;

        public LeaderboardFunctionClient(string functionUrl)
        {
            this._functionUrl = functionUrl;
        }

        async public Task<LeaderboardResponse> GetLeaderboard(int page, int pageSize, string mode, string region)
        {
            //using (WebClient webClient = new WebClient())
            using (HttpClient httpClient = new HttpClient())            
            {
                //string json = await webClient.DownloadStringTaskAsync($"{this._functionUrl}?page={page}&pageSize={pageSize}&mode={mode}&region={region}");
                string json = await httpClient.GetStringAsync($"{this._functionUrl}?page={page}&pageSize={pageSize}&mode={mode}&region={region}");                
                return JsonSerializer.Deserialize<LeaderboardResponse>(json);
            }
        }
    }
}
