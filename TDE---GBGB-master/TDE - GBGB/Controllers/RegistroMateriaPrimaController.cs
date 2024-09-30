using Microsoft.AspNetCore.Mvc;
using TDE___GBGB.Models;
using TDE___GBGB.Services;

namespace TDE___GBGB.Controllers
{
    public class RegistroMateriaPrimaController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class RegistroMateriaPrimaController : ControllerBase
        {
            private readonly RegistroMateriaPrimaService _registroMateriaPrimaService;

            public RegistroMateriaPrimaController(RegistroMateriaPrimaService registroMateriaPrimaService)
            {
                _registroMateriaPrimaService = registroMateriaPrimaService;
            }

            [HttpGet("ListaRegistro")]
            public ActionResult<ResultadoRegistroMateriaPrimaModel> ListaRegistroMateriaPrima()
            {
                try
                {
                    var resultado = _registroMateriaPrimaService.ListaRegistrosMateriaPrima();

                    if (resultado.Sucesso)
                    {
                        return Ok(resultado);
                    }
                    else
                    {
                        return NotFound(resultado);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ResultadoRegistroMateriaPrimaModel
                    {
                        Sucesso = false,
                        Mensagem = "Ocorreu um erro ao processar a solicitação."
                    });
                }
            }


            [HttpGet("ListaRegistro/{id}")]
            public ActionResult<ResultadoRegistroMateriaPrimaModel> ListaRegistroMateriaPrima(int id)
            {
                try
                {
                    var resultado = _registroMateriaPrimaService.ListaRegistroMateriaPrima(id);

                    if (resultado.Sucesso)
                    {
                        return Ok(resultado);
                    }
                    else
                    {
                        return NotFound(resultado);
                    }
                }

                catch (Exception ex)
                {
                    return StatusCode(500, new ResultadoRegistroMateriaPrimaModel
                    {
                        Sucesso = false,
                        Mensagem = "Ocorreu um erro ao processar a solicitação."
                    });
                }
            }

            [HttpPost("AdicionaRegistro")]
            public ActionResult<ResultadoRegistroMateriaPrimaModel> AdicionaRegistroMateriaPrima(RegistroMateriaPrimaModel registro)
            {
                try
                {
                    var resultado = _registroMateriaPrimaService.AdicionaRegistroMateriaPrima(registro);

                    if (resultado.Sucesso)
                    {
                        return Ok(resultado);
                    }
                    else
                    {
                        return BadRequest(resultado);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ResultadoRegistroMateriaPrimaModel
                    {
                        Sucesso = false,
                        Mensagem = "Ocorreu um erro ao processar a solicitação."
                        //Mensagem = $"Erro interno ao adicionar o registro: {ex.Message}"
                    });
                }
            }


            [HttpPut("EditaRegistro/{id}")]
            public IActionResult EditaRegistroMateriaPrima(RegistroMateriaPrimaModel registro, int id)
            {
                //try
                //{
                var resultado = _registroMateriaPrimaService.EditaRegistroMateriaPrima(registro, id);

                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado);
                }
            }

            [HttpDelete("DeletaRegistro/{id}")]
            public IActionResult DeletaRegistroMateriaPrima(int id)
            {
                _registroMateriaPrimaService.DeletaRegistroMateriaPrima(id);
                return NoContent();
            }
        }
    }
}
