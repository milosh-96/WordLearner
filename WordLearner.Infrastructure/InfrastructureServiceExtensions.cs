using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WordLearner.Domain.Services;
using WordLearner.Infrastructure.Services;
using Auth0.AspNetCore.Authentication;

namespace WordLearner.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    IConfiguration config
    )
        {
            string? connectionString = config.GetConnectionString("PostgresqlConnection");
            services.AddDbContextFactory<ApplicationDbContext>(options =>
             options.UseNpgsql(connectionString));

            services.AddScoped<IWordService, WordService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddAuth0WebAppAuthentication(options => {
                options.Domain = config.GetValue<string>("Auth0:Domain");
                options.ClientId = config.GetValue<string>("Auth0:ClientId");
            });
            return services;
        }
    }
}
