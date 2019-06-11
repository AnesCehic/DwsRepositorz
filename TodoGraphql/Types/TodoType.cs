using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using TodoGraphql.Models;

namespace TodoGraphql.Types
{
    public class TodoType : ObjectGraphType<Todo>
    {
        public TodoType()
        {
            Name = "Todo";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Todo id");
            Field(x => x.Title).Description("Todo title");
            Field(x => x.Description).Description("Todo description");
        }
    }
}
