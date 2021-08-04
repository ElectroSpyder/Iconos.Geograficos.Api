namespace Base.Repository.EntitiesRepository
{
    using Base.Repository.IRepository;
    using Iconos.Geograficos.Model.Context;
    using Iconos.Geograficos.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByFunc(Expression<Func<Ciudad, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
