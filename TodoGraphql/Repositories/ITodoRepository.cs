using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoGraphql.Models;

namespace TodoGraphql.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos();
        Todo AddTodo(Todo todo);
        Todo DeleteTodo(int id);
        Todo GetTodoById(int id);
    }
}
