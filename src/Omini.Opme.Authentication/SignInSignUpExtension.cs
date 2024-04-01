using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Omini.Opme.Authentication
{
    public class SignInSignUpExtension
    {
        private readonly ILogger _logger;

        public SignInSignUpExtension(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SignInSignUpExtension>();
        }

        [Function("SignInSignUpExtension")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
