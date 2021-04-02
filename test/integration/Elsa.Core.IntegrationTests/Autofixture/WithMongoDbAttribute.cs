using System;
using Elsa.Persistence.MongoDb.Extensions;
using Elsa.Testing.Shared.AutoFixture.Attributes;
using Elsa.Testing.Shared.Helpers;

namespace Elsa.Core.IntegrationTests.Autofixture
{
    public class WithMongoDbAttribute : ElsaHostBuilderBuilderCustomizeAttributeBase
    {
        public override Action<ElsaHostBuilderBuilder> GetBuilderCustomizer()
        {
            return builder => {
                builder.ElsaCallbacks.Add(elsa => {
                    elsa.UseMongoDbPersistence(opts => {
                        opts.ConnectionString = "mongodb://localhost:27017";
                        opts.DatabaseName = "IntegrationTests";
                    });
                });
            };
        }
    }
}