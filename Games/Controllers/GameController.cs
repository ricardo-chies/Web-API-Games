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
        private readonly AppDbContext _context;
        private readonly IGameAppService _appService;

        public GameController(AppDbContext context, IGameAppService appService)
        {
            _context = context;
            _appService = appService;
        }

       //[HttpGet]
       // public async Task<ActionResult<IEnumerable<GameDTO>>> GetGames()
       // {
       //     return await _appService.();
       // }

        //[HttpGet]
        //public ActionResult SelecionarTodos()
        //{
        //    var retorno = new ResponseDTO<IEnumerable<GameDTO>>();
        //    try
        //    {
        //        List<IEnumerable<GameDTO>> listaGames = new List<IEnumerable<GameDTO>>();
        //        listaGames.Add(_appService.SelecionarTodos().Result);

        //        retorno.Data = listaGames;
        //        retorno.Status = retorno.Data != null;
        //        retorno.Message = retorno.Status ? "Sucesso" : "Sem Dados";
        //        retorno.ExceptionMessage = null;
        //        return Ok(retorno);
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Status = false;
        //        retorno.ExceptionMessage = ex.Message;
        //        return BadRequest();
        //    }
        //}

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

        //[HttpPost]
        //public ActionResult Adicionar(GameDTO game)
        //{
        //    var retorno = new ResponseDTO<GameDTO>();
        //    try
        //    {
        //        List<GameDTO> listaGames = new List<GameDTO>();
        //        listaGames.Add(_appService.SelecionarId(game).Result);

        //        retorno.Data = listaGames;
        //        retorno.Status = retorno.Data != null;
        //        retorno.Message = retorno.Status ? "Sucesso" : "Sem Dados";
        //        retorno.ExceptionMessage = null;
        //        return Ok(retorno);
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno.Status = false;
        //        retorno.ExceptionMessage = ex.Message;
        //        return BadRequest();
        //    }
        //}

        // PUT: api/Games/5
        [HttpPut]
        public async Task<IActionResult> PutGame(int codigo_do_jogo, GameDTO game)
        {
            if (codigo_do_jogo != game.codigo_do_jogo)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(codigo_do_jogo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        //[HttpPost]
        //public async Task<ActionResult<GameDTO>> PostGame(GameDTO game)
        //{
        //    _context.Games.Add(game);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGame", new { codigo_do_jogo = game.COD_GAME }, game);
        //}

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int codigo_do_jogo)
        {
            var game = await _context.Games.FindAsync(codigo_do_jogo);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int codigo_do_jogo)
        {
            return _context.Games.Any(e => e.COD_GAME == codigo_do_jogo);
        }
    }
}
