namespace Iconos.Geograficos.Api.ProfileEntities
{
    using AutoMapper;
    using Iconos.Geograficos.Model.Entities;
    using Iconos.Geograficos.Model.ViewModels;

    public class IconosGeograficosProfile : Profile
    {
        public IconosGeograficosProfile()
        {
            CreateMap<IconosReograficos, IconosGeograficosViewModel>();

            CreateMap<IconosGeograficosViewModel, IconosReograficos>();
        }
    }
}
