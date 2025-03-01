using GetechnologiesMx.API.Configurations;
using GetechnologiesMx.Service.Models;
using GetechnologiesMx.Service.Services.IRepository;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using GetechnologiesMx.Service.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GetechnologiesMx.API.Controllers
{
    [ApiController]
    [ApiExceptionHandler]
    [Route("api/[controller]")]
    public class DirectorioRestServicePersonaController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfWork;
        IRepository<Persona> personaRepository;

        public DirectorioRestServicePersonaController(IUnitOfwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //personaRepository = new PersonaRepository(_unitOfWork, "GetechnologiesMx");
            personaRepository = new PersonaRepository(_unitOfWork);
        }

        //[HttpGet]
        [HttpGet("findPersonaByIdentificacion")]
        public async Task<ActionResult<IEnumerable<Persona>>> findPersonaByIdentificacion()
        {
            var personas = await personaRepository.findPersonaByIdentificacion();
            return personas;
        }

        //[HttpGet]
        [HttpGet("findPersonas")]
        public async Task<ActionResult<IEnumerable<Persona>>> findPersonas()
        {
            var personas = await personaRepository.findPersonas();
            return personas;
        }

        //[HttpPost]
        [HttpPost("StorePersona")]
        public async Task<ActionResult<Persona>> StorePersona(Persona persona)
        {
            var personas = await personaRepository.StorePersona(persona);
            return personas;
        }

       //[HttpDelete("{id}")]
        [HttpDelete("DeletePersonaByIdentificacion/{id}")]
        public async Task<IActionResult> DeletePersonaByIdentificacion(int id)
        {
            var personas = await personaRepository.DeletePersonaByIdentificacion(id);
            return personas;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
        {
            var personas = await personaRepository.Get();
            return personas;
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> CreatePersona(Persona persona)
        {
            var personas = await personaRepository.Create(persona);
            return personas;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var personas = await personaRepository.Delete(id);
            return personas;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersona(int id, Persona persona)
        {
            var personas = await personaRepository.Update(id, persona);
            return personas;
        }
    }
}