﻿using CarControl.Domain;
using CarControl.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarControl.APIVeiculos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistroDeMovimentoController : Controller
    {
        private readonly IMovimentoService _movimentoService;
        private readonly IVeiculoService _veiculoService;
        private readonly IVagaService _vagaService;

        public RegistroDeMovimentoController(IMovimentoService movimentoService, IVeiculoService veiculoService, IVagaService vagaService)
        {
            _movimentoService = movimentoService;
            _veiculoService = veiculoService;
            _vagaService = vagaService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Movimento>> Get() 
        {

            var movimentos = _movimentoService.ConsultaTodosMovimentos().ToList();

            if (movimentos == null)
            {
                return NotFound("Nenhum movimento encontrado");
            }

            return movimentos;   

        }


        [HttpGet("{cpfCondutor}", Name = "GetRegitro")]
        public ActionResult<Movimento> Get(string cpfCondutor)
        {

            var movimento = _movimentoService.ConsultaMovimentoDoVeiculo(cpfCondutor);

            if(movimento == null) 
            {
                return NotFound("Movimento não encontrado para o condutor");         
            }
            return movimento;

        }



        [HttpPost]   
        public  ActionResult PostEntrada(Movimento movimento)
        {
            if (movimento == null)
            {
                return BadRequest();
            }

            if (!_vagaService.VagaEstaOcupada(movimento.IdVaga))
            {
                return BadRequest("Esta vaga está ocupada");
            }
            
            var registroDeEntrada = _movimentoService.RegistrarEntrada(movimento);


            if (registroDeEntrada == null)
            {
                return BadRequest("Já existe uma entrada sem registro para o veículo em questão. Registre sua saída");
            }

            var cpfCondutor = _veiculoService.ObterVeiculos(movimento.IdVeiculo);
            

            return new CreatedAtRouteResult("GetRegitro", new { cpfCondutor = cpfCondutor.CpfCondutor}, movimento);
            
        }

        [HttpPut ("{idVaga:int}")]
        public ActionResult PutSaida(int idVaga, Movimento movimento) 
        { 
            if(idVaga != movimento.IdVaga)
            {
                return BadRequest();
            }

            _movimentoService.RegistrarSaida(movimento);

            return Ok(movimento);    


        }


    }
}
