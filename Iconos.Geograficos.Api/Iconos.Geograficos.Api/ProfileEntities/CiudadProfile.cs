namespace Iconos.Geograficos.Api.ProfileEntities
{
    using AutoMapper;
    using Iconos.Geograficos.Model.Entities;
    using Iconos.Geograficos.Model.ViewModels;

    public class CiudadProfile : Profile
    {
        public CiudadProfile()
        {
            CreateMap<Ciudad, CiudadViewModel>();

            CreateMap<CiudadViewModel, Ciudad>();
        }
    }
}
