using System;
using System.Threading.Tasks;
using Api.Domain.Contracts.Repositories;
using Api.Domain.Entities;
using Api.Infra.Context;
using Api.Infra.Repositories;

namespace Api.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApiContext _context;
        private IRepositoryBase<Product> _productRepository;

        public UnitOfWork(ApiContext context)
        {
            _context = context;
        }
        
        public IRepositoryBase<Product> GetProductRepository()
        {
            _productRepository = _productRepository ?? new RepositoryBase<Product>();
            return _productRepository;
        }
        
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}