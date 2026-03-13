using CursoOnline.Applications.Service;
using CursoOnline.DTOs.AlunoDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CursoOnline.Exceptions.DomainExcepition;

namespace CursoOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerAlunoDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("email/{email}")]
        public ActionResult<LerAlunoDto> ObterPorEmail(string email)
        {
            try
            {
                LerAlunoDto alunoDto = _service.ObterPorEmail(email);
                return Ok(alunoDto);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<LerAlunoDto> Adicionar(CriarAlunoDto alunoDto)
        {
            try
            {
                LerAlunoDto aluno = _service.Adicionar(alunoDto);
                return StatusCode(201, alunoDto);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<LerAlunoDto> Atualizar(string email, CriarAlunoDto alunoDto)
        {
            try
            {
                LerAlunoDto aluno = _service.Atualizar(email, alunoDto);
                return StatusCode(200, aluno);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{email}")]
        public ActionResult Remover(string email)
        {
            try
            {
                _service.Remover(email);
                return NoContent();  
            }
            catch (DomainException ex)
            {
                return BadRequest(ex); 
            }
        }
    }
}
