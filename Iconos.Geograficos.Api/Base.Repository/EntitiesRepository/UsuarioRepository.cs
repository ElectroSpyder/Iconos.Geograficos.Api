namespace Base.Repository.EntitiesRepository
{
    using Base.Repository.IRepository;
    using Iconos.Geograficos.Model.Context;
    using Iconos.Geograficos.Model.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IconoDBContext context;

        public UsuarioRepository(IconoDBContext iconoDBContext)
        {
            context = iconoDBContext;
        }
        public async Task<bool> Add(Usuario entity)
        {
            context.Usuarios.Add(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = context.Usuarios.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                context.Usuarios.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Usuario> Get(int id)
        {
            return await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetByFunc(Expression<Func<Usuario, bool>> filter)
        {
            return await context.Usuarios.Where(filter).ToListAsync();
        }

        public async Task<bool> Update(Usuario entity)
        {

            context.Usuarios.Update(entity);
            await context.SaveChangesAsync();
            return true;

        }
    }
}
