using Avenga.ToDoApp.Services_BusinessLayer.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.ToDoApp.Services_BusinessLayer.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<ToDoDto> GetTodos();
    }
}
