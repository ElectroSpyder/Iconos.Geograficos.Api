namespace Iconos.Geograficos.Api.Auth
{
    using AutoMapper;
    using Base.Repository.EntitiesRepository;
    using Iconos.Geograficos.Api.Model;
    using Iconos.Geograficos.Model.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UsuarioRepository _repository;
        //private readonly IMapper _mapper { get; set; }
        public AuthenticationController(UsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }        

        [HttpPost]
        [Route("registro")]
        public async Task<IActionResult> Register([FromBody]UsuarioViewModel model)
        {
            var usuarioExiste = _repository.GetByFunc(x => x.UserName == model.UserName);

            return Ok();
            /*_repository.Update(new Usuario
            {
                UserName = model.UserName
            });*/
        }
    }
}
