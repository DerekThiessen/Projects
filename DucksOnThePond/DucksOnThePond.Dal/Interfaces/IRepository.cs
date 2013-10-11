using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DucksOnThePond.Dal.Interfaces
{
    public interface IRepository<T>
    {
        //void Save(T entity);
        //void Update(T entity);
        //void Delete(int id);
        //T GetById(int id);
        IList<T> GetAll();
    }
}
