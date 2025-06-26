using Avenga.ToDoApp.DataAccess.Repositories;
using Avenga.ToDoApp.Domain;
using Avenga.ToDoApp.Services_BusinessLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.ToDoApp.Services_BusinessLayer.Services
{
    public class ToDoService : ITodoService
    {
        private readonly IRepository<Todo>_repository;

        public ToDoService(IRepository<Todo> todoRepository)
        {
            _repository = todoRepository;
        }
    }
}
