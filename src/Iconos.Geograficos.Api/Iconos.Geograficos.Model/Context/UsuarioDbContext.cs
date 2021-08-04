namespace Iconos.Geograficos.Model.Context
{
    using Iconos.Geograficos.Model.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class UsuarioDbContext : IdentityDbContext<Usuario>
    {
        private const string Schema = "usuarios";

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
        }
    }
}
