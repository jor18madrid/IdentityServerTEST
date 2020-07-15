using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                HttpClient client = _httpClientFactory.CreateClient();

                DiscoveryDocumentResponse discoveryDocument = await client.GetDiscoveryDocumentAsync("https://localhost:44310/");
                TokenResponse tokenResponse = await client.RequestClientCredentialsTokenAsync(
                    new ClientCredentialsTokenRequest
                    {
                        Address = discoveryDocument.TokenEndpoint,
                        ClientId = "client_worker_id",
                        ClientSecret = "client_worker_secret",
                        Scope = "ApiTest"
                    });

                client.SetBearerToken(tokenResponse.AccessToken);
                HttpResponseMessage response = await client.GetAsync("https://localhost:44356/secret");
                string content = await response.Content.ReadAsStringAsync();



                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation("{0} from WORKER", content);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
