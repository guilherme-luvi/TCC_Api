using APITCC2021.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APITCC2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoencaController : ControllerBase
    {
        //private readonly DoencasRepo _repo;
        //public DoencaController(DoencasRepo repo)
        //{
        //    _repo = repo;
        //}

        //[HttpGet]
        //public async Task<ActionResult<dynamic>> GetAll()
        //{
        //    var resp = await _repo.GetDoencas();
        //    return Ok(resp);
        //}
    }
}
