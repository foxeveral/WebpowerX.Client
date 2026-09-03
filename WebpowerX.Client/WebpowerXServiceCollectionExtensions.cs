using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using WebpowerX.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 为 Microsoft.Extensions.DependencyInjection 提供的注册入口。
    /// </summary>
    public static class WebpowerXServiceCollectionExtensions
    {
        /// <summary>
        /// 注册 WebpowerX typed client。
        /// </summary>
        /// <param name="services">服务容器。</param>
        /// <param name="configure">客户端基础配置。</param>
        /// <returns>同一个服务集合，便于链式调用。</returns>
        public static IServiceCollection AddWebpowerXApiClient(this IServiceCollection services, Action<WebpowerXApiOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            services.AddOptions<WebpowerXApiOptions>().Configure(configure);
            services.AddHttpClient<IWebpowerXApiClient, WebpowerXApiClient>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<WebpowerXApiOptions>>().Value;
                client.BaseAddress = new Uri(NormalizeBaseUrl(options.BaseUrl));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }

        private static string NormalizeBaseUrl(string baseUrl)
            => baseUrl.EndsWith("/", StringComparison.Ordinal) ? baseUrl : baseUrl + "/";
    }
}
