using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IGenericRepostory<T> where T : BaseEntity
    {
        T GetEmployee(int id);
        IEnumerable<T> GetAll();
        void Delete(T Entity);
        void Update(T Entity);
        void Create(T Entity);
    }
}
