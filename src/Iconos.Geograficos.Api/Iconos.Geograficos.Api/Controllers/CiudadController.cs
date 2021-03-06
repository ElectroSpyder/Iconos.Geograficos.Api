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
                var result = _repository.GetByFunc(x => x.Denominacion == den).ToList();
                if (result == null) return NotFound();
                
                var map = _mapper.Map<List<CiudadViewModel>>(result);

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

        [HttpPut("{name}")]
        public async Task<ActionResult<CiudadViewModel>> Put(string name, CiudadViewModel model)
        {
            try
            {
                if (model == null) return StatusCode(StatusCodes.Status400BadRequest, "Modelo nulo o con errores");
                var oldModel = _repository.GetByFunc(x => x.Denominacion == name).ToList();

                if (!oldModel.Any()) return NotFound($"No se encontro la ciudad {name}");

                _mapper.Map(model, oldModel[0]);   //el destino es oldModel ya que es donde queremosmodificar

                if (await _repository.Update(oldModel[0])) return Ok(_mapper.Map<CiudadViewModel>(oldModel[0]));

                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{nombre}")]
        public async Task<ActionResult<bool>> Delete(string nombre)
        {
            try
            {
                var entityToDelete = _repository.GetByFunc(x => x.Denominacion == nombre).ToList();
                if (!entityToDelete.Any()) return NotFound();

                var result = await _repository.Delete(entityToDelete[0].IdCiudad);

                if (result) return Ok(true);

                return StatusCode(StatusCodes.Status500InternalServerError, "Algo ocurrio que no se pudo borrar el genero");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
