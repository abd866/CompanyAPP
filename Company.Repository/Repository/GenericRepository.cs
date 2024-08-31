using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepostory<T> where T : BaseEntity
    {
        private readonly CompanyDBContext _dBContext;

        public GenericRepository(CompanyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void Create(T Entity)
        {
            _dBContext.Set<T>().Add(Entity);
            _dBContext.SaveChanges();
        }

        public void Delete(T Entity)
        {
            _dBContext.Set<T>().Remove(Entity);
            _dBContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
          return  _dBContext.Set<T>().ToList();
        }

        public T GetEmployee(int id)
        {
            return _dBContext.Set<T>().Find(id);
        }

        public void Update(T Entity)
        {
            _dBContext.Set<T>().Update(Entity);
            _dBContext.SaveChanges();
        }
    }
}
