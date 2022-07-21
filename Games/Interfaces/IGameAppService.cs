using Games.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Interfaces
{
    public interface IGameAppService
    {
        //Task<IEnumerable<GameDTO>> SelecionarTodos();
        public Task<GameDTO> SelecionarId(int codigo_do_jogo);
        //public Task<GameDTO> Adicionar(GameDTO game);
    }
}
