using System;
using System.Collections.Generic;
using System.Text;
using TodoGraphql.Models;

namespace TodoGraphql.DataAccess.Respositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _db;

        public TodoRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _db.Todos;
        }
    }
}
