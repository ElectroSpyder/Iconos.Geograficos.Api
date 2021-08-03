namespace Base.Repository.IRepository
{
    using Iconos.Geograficos.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface ICiudadRepository
    {
        Task<IEnumerable<Ciudad>> GetAll();
        Task<Ciudad> Get(int id);
        Task<bool> Add(Ciudad entity);
        Task<bool> Update(Ciudad entity);
        Task<bool> Delete(int id);
        Task<Ciudad> GetByFunc(Expression<Func<Ciudad, bool>> filter);
    }
}
