using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Games.DTO;
using Games.DATA;
using Games.Interfaces;
using System;

namespace Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameAppService _appService;

        public GameController(IGameAppService appService)
        {
            _appService = appService;
        }


        [HttpGet("id")]
        public ActionResult SelecionarId (int codigo_do_jogo)
        {
            var retorno = new ResponseDTO<GameDTO>();
            try
            {
                List<GameDTO> listaGames = new List<GameDTO>();
                listaGames.Add(_appService.SelecionarId(codigo_do_jogo).Result);

                retorno.Data = listaGames;
                retorno.Status = retorno.Data != null;
                retorno.Message = retorno.Status ? "Sucesso" : "Sem Dados";
                retorno.ExceptionMessage = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.Status = false;
                retorno.ExceptionMessage = ex.Message;
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Adicionar(GameDTO game)
        {
            var retorno = new ResponseDTO<GameDTO>();
            try
            {
                List<GameDTO> listaGames = new List<GameDTO>();
                listaGames.Add(_appService.Adicionar(game).Result);

                retorno.Data = listaGames;
                retorno.Status = retorno.Data != null;
                retorno.Message = retorno.Status ? "Sucesso" : "Sem Dados";
                retorno.ExceptionMessage = null;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.Status = false;
                retorno.ExceptionMessage = ex.Message;
                return BadRequest();
            }
        }

    }
}
