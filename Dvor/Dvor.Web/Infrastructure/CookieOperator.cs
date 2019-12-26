using Dvor.Web.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dvor.Web.Infrastructure
{
    public static class CookieOperator
    {
        public static CookieAuthSettings AddCookieAuthSettings(IConfiguration configuration,
            IServiceCollection services)
        {
            var settingsSection = configuration.GetSection(nameof(CookieAuthSettings));
            services.Configure<CookieAuthSettings>(settingsSection);

            return settingsSection.Get<CookieAuthSettings>();
        }
    }
}