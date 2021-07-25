namespace Iconos.Geograficos.Model.Context
{
    using Iconos.Geograficos.Model.Entities;
    using Microsoft.EntityFrameworkCore;
    
    public class IconoDBContext : DbContext
    {
        public IconoDBContext(DbContextOptions<IconoDBContext> options) : base(options)
        {

        }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<IconosReograficos> Iconos { get; set; }
        public DbSet<Continente> Continentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
