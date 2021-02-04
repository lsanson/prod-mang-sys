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

        public T Insert(T entity)
        {
            _dataSet.Add(entity);
            return entity;
        }

        public IEnumerable<T> InsertList(IEnumerable<T> entities)
        {
            _dataSet.AddRange(entities);
            return entities;
        }

        public T GetImportation(int id)
        {
            return _dataSet.Find(id);
        }

        public IEnumerable<T> GetImportations()
        {
            return _dataSet.AsNoTracking();
        }
    }
}