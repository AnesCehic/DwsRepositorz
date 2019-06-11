using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using TodoGraphql.Models;
using TodoGraphql.Repositories;
using TodoGraphql.Types;

namespace TodoGraphql.Mutations
{
    public class TodoMutation : ObjectGraphType
    {
        public TodoMutation(ITodoRepository todoRepository)
        {
            Field<TodoType>(
                "addTodo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TodoInputType>> { Name = "todo" }),
                resolve: ctx =>
                {
                    var todo = ctx.GetArgument<Todo>("todo");
                    return todoRepository.AddTodo(todo);
                });
            Field<TodoType>(
                "removeTodo",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return todoRepository.DeleteTodo(id);
                });
        }
    }
}
