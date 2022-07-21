using AutoMapper;
using Games.DTO;
using Games.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.AutoMapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDTO, GameEntity>()
                .ForMember(target => target.COD_GAME, options => options.MapFrom(source => source.codigo_do_jogo))
                .ForMember(target => target.NOME_GAME, options => options.MapFrom(source => source.nome_do_jogo))
                .ForMember(target => target.HORAS_ZERAR, options => options.MapFrom(source => source.horas_para_zerar))
                .ForMember(target => target.GENERO_GAME, options => options.MapFrom(source => source.genero_do_jogo))
                .ForMember(target => target.ANO_LANCAMENTO, options => options.MapFrom(source => source.ano_de_lancamento));
            CreateMap<GameEntity, GameDTO>()
                .ForMember(target => target.codigo_do_jogo, options => options.MapFrom(source => source.COD_GAME))
                .ForMember(target => target.nome_do_jogo, options => options.MapFrom(source => source.NOME_GAME))
                .ForMember(target => target.horas_para_zerar, options => options.MapFrom(source => source.HORAS_ZERAR))
                .ForMember(target => target.genero_do_jogo, options => options.MapFrom(source => source.GENERO_GAME))
                .ForMember(target => target.ano_de_lancamento, options => options.MapFrom(source => source.ANO_LANCAMENTO));

        }
    }
}
