using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public int code { get; set; }
        public ICollection<Employee> Employees { get; set; }=new List<Employee>();
    }
}
