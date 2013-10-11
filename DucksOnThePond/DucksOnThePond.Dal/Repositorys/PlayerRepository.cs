using DucksOnThePond.Helpers;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using DucksOnThePond.Dal.Interfaces;

namespace DucksOnThePond.Dal.Repositorys
{
    public class PlayerRepository<T> : IRepository<T>
        where T: class
    {
        public IList<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<T>().ToList<T>();
            }
        }
        
    }
}