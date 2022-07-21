using AutoMapper;
using Games.DATA;
using Games.DTO;
using Games.Entity;
using Games.Interfaces;
using Games.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Service
{
    public class GameAppService : IGameAppService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameAppService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameDTO> SelecionarId(int codigo_do_jogo)
        {
            var result = await _gameRepository.GetId(codigo_do_jogo);
            var response = _mapper.Map<GameDTO>(result);
            return response;
        }

        //public async Task<IEnumerable<GameDTO>> SelecionarTodos()
        //{
        //    var result = await _gameRepository.GetAll();
        //    var response = _mapper.Map<IEnumerable<GameDTO>>(result);
        //    return response;
        //}

        //public async Task<GameDTO> Adicionar(GameDTO game)
        //{
        //    var response = _mapper.Map<GameEntity>(game);
        //    var result = await _gameRepository.Add(response);
        //    return result;
        //}
    }
}
