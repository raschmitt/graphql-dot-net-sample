namespace GraphQL.Sample.Api.GraphQL
{
    public class Schema: global::GraphQL.Types.Schema
    {
        public Schema(IDependencyResolver resolver): base(resolver)
        {           
            Query = resolver.Resolve<Query>();
            Mutation = resolver.Resolve<Mutation>();
        }
    }
}
