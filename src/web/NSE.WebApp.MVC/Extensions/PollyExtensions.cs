using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace NSE.WebApp.MVC.Extensions
{
    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
        {
            var retryWaitPolice = HttpPolicyExtensions
               .HandleTransientHttpError()
               .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
               (exception, timeSpan, retryCount, context) => {
                   Console.ForegroundColor = ConsoleColor.Blue;
                   Console.WriteLine($"Tentendo pela {retryCount} vez");
                   Console.ForegroundColor = ConsoleColor.White;
               });

            return retryWaitPolice;
        }

    }
}
