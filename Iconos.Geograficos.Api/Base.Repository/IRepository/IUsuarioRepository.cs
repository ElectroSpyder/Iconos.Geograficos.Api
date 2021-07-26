namespace Base.Repository.IRepository
{
    using Iconos.Geograficos.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> Get(int id);
        Task<bool> Add(Usuario entity);
        Task<bool> Update(Usuario entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<Usuario>> GetByFunc(Expression<Func<Usuario, bool>> filter);
    }
}
