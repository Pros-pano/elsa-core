using System;
using System.Threading.Tasks;
using Elsa.Abstractions.Multitenancy;
using Elsa.Attributes;
using Elsa.WorkflowSettings.Persistence.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.WorkflowSettings.Persistence.EntityFramework.PostgreSql
{
    [Feature("WorkflowSettings:EntityFrameworkCore:PostgreSql")]
    public class Startup : EntityFrameworkWorkflowSettingsStartupBase
    {
        protected override string ProviderName => "PostgreSql";
        protected override void Configure(DbContextOptionsBuilder options, string connectionString) => options.UseWorkflowSettingsPostgreSql(connectionString);
        protected override async Task Configure(DbContextOptionsBuilder options, IServiceProvider serviceProvider)
        {
            var tenantProvider = serviceProvider.GetRequiredService<ITenantProvider>();
            var tenant = await tenantProvider.GetCurrentTenantAsync();
            var connectionString = tenant.GetDatabaseConnectionString();

            options.UseWorkflowSettingsPostgreSql(connectionString);
        }
    }
}