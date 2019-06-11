using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoGraphql.Models;

namespace TodoGraphql.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _db;

        public TodoRepository(AppDbContext db)
        {
            _db = db;
        }

        public Todo AddTodo(Todo todo)
        {
            _db.Todos.Add(todo);
            _db.SaveChanges();

            return todo;
        }

        public Todo DeleteTodo(int id)
        {
            var todo = _db.Todos.Find(id);

            _db.Todos.Remove(todo);
            _db.SaveChanges();

            return todo;
        }

        public Todo GetTodoById(int id)
        {
            return _db.Todos.Find(id);
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _db.Todos;
        }
    }
}
