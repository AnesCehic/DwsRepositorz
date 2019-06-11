using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoGraphql.Models;
using TodoGraphql.Repositories;
using TodoGraphql.Types;

namespace TodoGraphql.Queries
{
    public class TodoQuery : ObjectGraphType
    {
        public TodoQuery(ITodoRepository todoRepository)
        {
            Field<ListGraphType<TodoType>>(
                "Todos",
                resolve: ctx => todoRepository.GetTodos());
            Field<TodoType>(
                "getTodoById",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return todoRepository.GetTodoById(id);
                });
        }
    }
}
