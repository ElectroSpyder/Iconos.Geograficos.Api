namespace Iconos.Geograficos.Api.Controllers
{
    using AutoMapper;
    using Base.Repository.IRepository;
    using Iconos.Geograficos.Api.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class IconosController : ControllerBase
    {
        private readonly IIconoRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator linkGenerator;

        public IconosController(IIconoRepository entityRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = entityRepository;
            _mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<List<IconosGeograficosViewModel>>> GetAll()
        {
            try
            {
                var listIconos = await _repository.GetAll();
                if (listIconos == null) return NotFound();
                if (listIconos.Count() == 0) return StatusCode(StatusCodes.Status204NoContent, "Lista sin Iconos Geogfraficos");

                var result = _mapper.Map<List<IconosGeograficosViewModel>>(listIconos.ToList());

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
