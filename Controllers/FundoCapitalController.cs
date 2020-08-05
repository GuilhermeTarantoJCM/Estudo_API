using System;
using System.Collections.Generic;
using AulaAPI.Models;
using AulaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AulaAPI.Controllers
{
    [ApiController]
    public class FundoCapitalController : ControllerBase
    {
        private readonly IFundoCapitalRepository _repositorio;

        public FundoCapitalController(IFundoCapitalRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("v1/fundoscapital")]
        public IActionResult ListarFundos()
        {
            return Ok(_repositorio.ListarFundos());
        }

        [HttpPost("v1/fundoscapital")]
        public IActionResult AdicionarFundo([FromBody] FundoCapital fundo)
        {
            _repositorio.Adicionar(fundo);
            return Ok();
        }

        [HttpPut("v1/fundoscapital/{id}")]
        public IActionResult AlterarFundo(Guid id, [FromBody] FundoCapital fundo)
        {
            var fundoAntigo = _repositorio.ObterporId(id);

            if(fundoAntigo == null)
            {
                return NotFound();
            }

            fundoAntigo.Nome = fundo.Nome;
            fundoAntigo.ValorAtual = fundo.ValorAtual;
            fundoAntigo.ValorNecessario = fundo.ValorNecessario;
            fundoAntigo.DataResgate = fundo.DataResgate;
            _repositorio.Alterar(fundoAntigo);
            
            return Ok();
        }

        [HttpGet("v1/fundoscapital/{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var fundoAntigo = _repositorio.ObterporId(id);

            if(fundoAntigo == null)
            {
                return NotFound();
            }
            
            return Ok(fundoAntigo);
        }

        [HttpDelete("v1/fundoscapital/{id}")]
        public IActionResult RemoverFundo(Guid id)
        {
            var fundo = _repositorio.ObterporId(id);

            if(fundo == null)
            {
                return NotFound();
            }
            
            _repositorio.RemoverFundo(fundo);
            return Ok();
        }
    }
}