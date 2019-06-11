using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace TodoGraphql.Types
{
    public class TodoInputType : InputObjectGraphType
    {
        public TodoInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("description");
        }
    }
}
