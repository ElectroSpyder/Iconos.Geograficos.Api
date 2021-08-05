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

    public class CiudadRepository : ICiudadRepository
    {
        private readonly IconoDBContext context;

        public CiudadRepository(IconoDBContext iconoDBContext)
        {
            context = iconoDBContext;
        }
        public async Task<bool> Add(Ciudad entity)
        {
            context.Ciudades.Add(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await context.Ciudades.Include(x => x.IconosGeograficos).SingleAsync(x=> x.IdCiudad == id);
            if (entity == null) return false;

            if (entity.IconosGeograficos.Any())
            {
                foreach (var item in entity.IconosGeograficos)
                {
                    context.Iconos.Remove(item);
                }              
            }
           
            context.Ciudades.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<Ciudad> Get(int id)
        {
            return await context.Ciudades.FirstOrDefaultAsync(x => x.IdCiudad == id);
        }

        public async Task<IEnumerable<Ciudad>> GetAll()
        {
            return await context.Ciudades.ToListAsync();
        }       

        public IQueryable<Ciudad> GetByFunc(Expression<Func<Ciudad, bool>> filter)
        {            
            if (filter != null)
                return context.Ciudades.Where(filter).AsQueryable();
            return null;
        }

        public async Task<bool> Update(Ciudad entity)
        {

            context.Ciudades.Update(entity);
            await context.SaveChangesAsync();
            return true;

        }
    }
}
