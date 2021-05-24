using APITCC2021.Models.Api;
using APITCC2021.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APITCC2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosController : Controller
    {
        private readonly DiagnosticosRepo _repo;
        public DiagnosticosController(DiagnosticosRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("gerar")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Gerar([FromBody] Respostas respostas)
        {
            try
            {
                var userId = int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);

                var resp = await _repo.GetResults(respostas.SitomasIds);

                await _repo.SaveResults(resp, userId);

                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("meus")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Meus()
        {
            try
            {
                var userId = int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);

                var resp = await _repo.GetHistory(userId);

                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/detalhes")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Meus(int id)
        {
            try
            {
                var resp = await _repo.Detalhes(id);

                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
