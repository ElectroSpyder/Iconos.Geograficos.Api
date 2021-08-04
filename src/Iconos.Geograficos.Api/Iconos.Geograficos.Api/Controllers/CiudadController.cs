namespace Iconos.Geograficos.Api.Controllers
{
    using AutoMapper;
    using Base.Repository.IRepository;
    using Iconos.Geograficos.Model.Entities;
    using Iconos.Geograficos.Model.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public CiudadController(ICiudadRepository ciudadRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = ciudadRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{den}")]      //get por denominacion
        public async Task<ActionResult> Get(string den)
        {
            try
            {
                var result = await _repository.GetByFunc(x => x.Denominacion == den);
                if (result == null) return NotFound();
                
                var map = _mapper.Map<CiudadViewModel>(result);

                return Ok(map);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("/get/cities")]    //6_ listado de ciudades
        public async Task<ActionResult<List<SoloCiudadViewModel>>> Getcities()
        {
            try
            {
                var listEntity = await _repository.GetAll();

                if (listEntity.Any())
                {
                    var model = _mapper.Map<CiudadViewModel[]>(listEntity);
                    var result = new List<SoloCiudadViewModel>();

                    foreach (var item in model)
                    {
                        result.Add(new SoloCiudadViewModel
                        {
                            Denominacion = item.Denominacion,
                            CantidadHabitantes = item.CantidadHabitantes,
                            Imagen = item.ImagenUrl
                        }
                        );
                    }

                    return Ok(result);
                }


                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]   //7_ TODO: probar, get todas las ciudades junto a los iconos geograficos 
        public async Task<ActionResult<CiudadViewModel>> Get()
        {
            try
            {
                var listEntity = await _repository.GetAll();
               
                if (listEntity!= null)
                {
                     var model = _mapper.Map<CiudadViewModel[]>(listEntity);
                    return Ok(model);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            

        }

        [HttpPost]
        public async Task<ActionResult<CiudadViewModel>> Post(CiudadViewModel model)
        {
            try
            {
                var map = _mapper.Map<Ciudad>(model);
                var result = await _repository.Add(map);
                if (result)
                {
                    return Created($"/api/Ciudad/{map.Denominacion}", _mapper.Map<CiudadViewModel>(map));
                }
                                
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return BadRequest();

        }
    
    }
}
