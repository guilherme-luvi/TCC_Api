using APITCC2021.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APITCC2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SintomaController : ControllerBase
    {
        private readonly SintomasRepo _repo;
        public SintomaController(SintomasRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var resp = await _repo.GetSintomas();
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            var resp = await _repo.GetSintomaById(id);
            return Ok(resp);
        }
    }
}
