using APITCC2021.Models.Api;
using APITCC2021.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APITCC2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiagnosticosController : Controller
    {
        private readonly AssociacoesRepo _repo;
        public DiagnosticosController(AssociacoesRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("gerar")]
        public async Task<ActionResult<dynamic>> SignUp([FromBody] Respostas respostas)
        {
            try
            {
                var resp = await _repo.GetAssociacoes(respostas.SitomasIds);
                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
