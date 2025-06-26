using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.ToDoApp.Domain
{
    public class Todo : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }
    }
}
