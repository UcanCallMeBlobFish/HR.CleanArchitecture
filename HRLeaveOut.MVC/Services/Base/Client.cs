using System.Net.Http;

namespace HRLeaveOut.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient => _httpClient;
    }
}