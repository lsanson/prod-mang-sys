using System;
using System.Collections.Generic;
using Api.Domain.Contracts.Repositories;

namespace Api.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}