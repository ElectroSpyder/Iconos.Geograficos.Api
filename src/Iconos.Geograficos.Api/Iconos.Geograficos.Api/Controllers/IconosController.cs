namespace Iconos.Geograficos.Api.Controllers
{
    using AutoMapper;
    using Base.Repository.IRepository;
    using Iconos.Geograficos.Api.Model;
    using Iconos.Geograficos.Model.Entities;
    using Iconos.Geograficos.Model.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class IconosController : ControllerBase
    {
        private readonly IIconoRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public IconosController(IIconoRepository entityRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = entityRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<IconosGeograficosViewModel>> Get(string name)
        {
            try
            {
                var result = await _repository.GetByFunc(x => x.Denominacion == name);
                if (result == null) return NotFound();

                return Ok(_mapper.Map<IconosGeograficosViewModel>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<IconosGeograficosViewModel>>> GetAll()
        {
            try
            {
                var listIconos = await _repository.GetAll();
                if (listIconos == null) return NotFound();

                if (!listIconos.Any()) return StatusCode(StatusCodes.Status204NoContent, "Lista sin Iconos Geográficos");

                var result = _mapper.Map<List<IconosGeograficosViewModel>>(listIconos.ToList());

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IconosGeograficosViewModel>> Post(IconosGeograficosViewModel model)
        {
            try
            {
                var location = _linkGenerator.GetPathByAction("Get", "Iconos", new { name = model.Denominacion });

                if (string.IsNullOrWhiteSpace(location)) return BadRequest("No puede usar el Nombre");

                if (model == null) return StatusCode(StatusCodes.Status400BadRequest, "Modelo nulo o con errores");
                var modelToUpdate = _mapper.Map<IconosReograficos>(model);

                
                if (await _repository.Add(modelToUpdate))
                {
                    return Created(location, _mapper.Map<IconosGeograficosViewModel>(modelToUpdate));
                }
               
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar");

               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{name}")]
        public  async Task<ActionResult<IconosGeograficosViewModel>> Put(string name, IconosGeograficosViewModel model)
        {
            try
            {
                if (model == null) return StatusCode(StatusCodes.Status400BadRequest, "Modelo nulo o con errores");
                var oldModel = await _repository.GetByFunc(x => x.Denominacion == name);

                if (oldModel == null) return NotFound($"No se encontro el Icono Geográfico {name}");

                _mapper.Map(model, oldModel);   //el destino es oldModel ya que es donde queremosmodificar

                if (await _repository.Add(oldModel)) return Ok(_mapper.Map<IconosGeograficosViewModel>(oldModel));

                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet()]
        [Route("search/date")]
        public async Task<ActionResult<List<IconosGeograficosViewModel>>> SearchByDate(DateTime date)
        {
            try
            {
                var result = await _repository.GetByFunc(x => x.FechaCreacion == date);
                if (result == null) return NotFound();

                return Ok(_mapper.Map<IconosGeograficosViewModel>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet()]
        [Route("search/idCity")]
        public async Task<ActionResult<List<IconosGeograficosViewModel>>> SearchByCity(int idCity)
        {
            try
            {
                var result = await _repository.GetByFunc(x => x.Ciudad.IdCiudad == idCity);
                if (result == null) return NotFound();

                return Ok(_mapper.Map<IconosGeograficosViewModel>(result));
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
                var entityToDelete = await _repository.GetByFunc(x => x.Denominacion == nombre);
                if (entityToDelete == null) return NotFound();

                var result = await _repository.Delete(entityToDelete.IdCiudad);

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
