using System.Threading.Tasks;
using Api.Domain.Contracts.Repositories;
using Api.Domain.Entities;

namespace Api.Infra.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepositoryBase<Product> GetProductRepository();
        Task Commit();
    }
}