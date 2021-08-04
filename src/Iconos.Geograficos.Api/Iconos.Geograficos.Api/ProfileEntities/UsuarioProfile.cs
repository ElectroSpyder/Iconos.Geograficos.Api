namespace Iconos.Geograficos.Api.ProfileEntities
{
    using AutoMapper;
    using Iconos.Geograficos.Api.Model;
    using Iconos.Geograficos.Model.Entities;

    public class UsuarioProfile: Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();

            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
