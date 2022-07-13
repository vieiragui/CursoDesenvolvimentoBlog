using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CursoDesenvolvimentoWeb.Models;

namespace CursoDesenvolvimentoWeb.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IList<TEntity>> All();
        Task<TEntity> GetPerId(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task Remove(Guid id);
    }
}