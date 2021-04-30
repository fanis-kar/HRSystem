using HRSystem.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRSystem.BLL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
