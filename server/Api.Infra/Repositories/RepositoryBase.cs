using System;
using System.Collections.Generic;
using Api.Domain.Contracts.Repositories;
using Api.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        private ApiContext _context;
        private DbSet<T> _dataSet;

        public RepositoryBase(ApiContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}