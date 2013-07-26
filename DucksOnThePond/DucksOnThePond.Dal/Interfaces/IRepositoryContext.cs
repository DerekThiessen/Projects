using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;
using DucksOnThePond.Dal.Infrastructure;
using DucksOnThePond.Dal.Interfaces;

namespace DucksOnThePond.Dal.Interfaces
{
    public interface IRepositoryContext
    {
        IObjectSet<T> GetObjectSet<T>() where T : class;
        int SaveChanges();
        void Terminate();
    }
}
