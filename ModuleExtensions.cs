using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Piranha.Mailer.Interfaces;
using Piranha.Mailer.Models;
using System;

namespace Piranha.Mailer
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddSendGridModule(this IServiceCollection services, IConfiguration smtpSettings)
        {
            App.Modules.Register<Module>();

            services.Configure<SendGridSettings>(smtpSettings.GetSection("SendGridSettings"));
            services.AddSingleton<IMailer, SendGridMailer>();

            return services;
        }

        public static IServiceCollection AddSendGridModule(this IServiceCollection services, Action<SendGridSettings> smptSettings)
        {
            App.Modules.Register<Module>();

            services.Configure(smptSettings);
            services.AddSingleton<IMailer, SendGridMailer>();

            return services;
        }

        public static IApplicationBuilder UseSendGridModule(this IApplicationBuilder builder)
        {
            return builder;
        }
    }
}
