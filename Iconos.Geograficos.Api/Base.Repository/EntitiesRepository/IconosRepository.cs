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
    using System.Threading.Tasks;

    public class IconosRepository : IIconoRepository
    {
        private readonly IconoDBContext context;
        public IconosRepository(IconoDBContext iconoDBContext)
        {
            context = iconoDBContext;
        }

        public async Task<bool> Add(IconosReograficos entity)
        {
            context.Iconos.Add(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = context.Iconos.FirstOrDefault(x => x.IdIcono == id);
            if (entity != null)
            {
                context.Iconos.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IconosReograficos> Get(int id)
        {
            return await context.Iconos.FirstOrDefaultAsync(x => x.IdIcono == id);
        }

        public async Task<IEnumerable<IconosReograficos>> GetAll()
        {
            return await context.Iconos.ToListAsync();
        }

        public async Task<IEnumerable<IconosReograficos>> GetByFunc(Expression<Func<IconosReograficos, bool>> filter)
        {
            return await context.Iconos.Where(filter).ToListAsync();
        }

        public async Task<bool> Update(IconosReograficos entity)
        {

            context.Iconos.Update(entity);
            await context.SaveChangesAsync();
            return true;

        }
    }
}
