using System;
using System.Collections.Generic;

namespace Api.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> 
        where T : class
    {
        T Create(T entity);
        T Read(Guid id);
        IEnumerable<T> ReadAll();
        T Update(T entity);
        void Delete(Guid id);
    }
}