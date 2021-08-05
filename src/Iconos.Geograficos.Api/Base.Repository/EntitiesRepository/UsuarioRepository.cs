namespace Base.Repository.EntitiesRepository
{
    using Base.Repository.IRepository;
    using Iconos.Geograficos.Model.Context;
    using Iconos.Geograficos.Model.Entities;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Add(Usuario entity)
        {
            try
            {
                _ = _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Usuario> GetByFunc(Expression<Func<Usuario, bool>> filter)
        {
            if (filter == null) return null;
            return await _context.Users.FindAsync(filter);
        }

        public async Task<bool> Update(Usuario entity)
        {
            try
            {
                var result =  _context.Users.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
