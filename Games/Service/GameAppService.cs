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
            GameEntity gameEntity = await _gameRepository.GetId(codigo_do_jogo);
            GameDTO gameDTO = _mapper.Map<GameDTO>(gameEntity);
            return gameDTO;
        }

        public async Task<GameDTO> Adicionar(GameDTO game)
        {
            GameEntity gameEntity = _mapper.Map<GameEntity>(game);
            await _gameRepository.Add(gameEntity);
            return game;
        }

    }
}
