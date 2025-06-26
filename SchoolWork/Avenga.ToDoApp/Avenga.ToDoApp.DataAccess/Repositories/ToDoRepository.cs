using Avenga.ToDoApp.DataAccess.Data;
using Avenga.ToDoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.ToDoApp.DataAccess.Repositories
{
    public class ToDoRepository : IRepository<Todo>
    {
        public void Create(Todo entity)
        {
            entity.Id = StaticDb.Todos.Count + 1;
            StaticDb.Todos.Add(entity);
        }

        public void Delete(int id)
        {
            Todo todoFromDb = StaticDb.Todos.SingleOrDefault(x => x.Id == id);
            StaticDb.Todos.Remove(todoFromDb);
        }

        public IEnumerable<Todo> GetAll()
        {
            return StaticDb.Todos;
        }
        
        public Todo GetById(int id)
        {
            return StaticDb.Todos.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Todo entity)
        {
            Todo todoFromDb = StaticDb.Todos.SingleOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Todos.IndexOf(todoFromDb);
            StaticDb.Todos[index] = entity;
        }
    }
}
