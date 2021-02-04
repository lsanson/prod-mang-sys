using System;
using System.Collections.Generic;

namespace Api.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> 
        where T : class
    {
        T Insert(T entity);
        IEnumerable<T> InsertList(IEnumerable<T> entities);
        T GetImportation(int id);
        IEnumerable<T> GetImportations();
    }
}