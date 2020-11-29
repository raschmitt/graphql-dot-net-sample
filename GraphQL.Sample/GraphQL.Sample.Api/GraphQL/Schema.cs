using System;
using GraphQL.Utilities;

namespace GraphQL.Sample.Api.GraphQL
{
    public class Schema: global::GraphQL.Types.Schema
    {
        public Schema(IServiceProvider serviceProvider): base(serviceProvider)
        {           
            Query = serviceProvider.GetRequiredService<Query>();
            Mutation = serviceProvider.GetRequiredService<Mutation>();
        }
    }
}
