using System;
using System.Collections.Generic;
using System.Text;

namespace TodoGraphql.DataAccess.Respositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos();
    }
}
