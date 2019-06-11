using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoGraphql.Controllers;
using TodoGraphql.Mutations;
using TodoGraphql.Queries;

namespace TodoGraphql.Schema
{
    public class TodoSchema : GraphQL.Types.Schema
    {
        public TodoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TodoQuery>();
            Mutation = resolver.Resolve<TodoMutation>();
        }
    }
}
