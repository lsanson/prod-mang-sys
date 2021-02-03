using System;
using System.Collections.Generic;

namespace Api.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> 
        where T : class
    {
        T Create(T entity);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}