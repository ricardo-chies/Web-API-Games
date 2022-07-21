using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.DTO
{
    public class GameDTO
    {
        [Key]
        public int codigo_do_jogo { get; set; }
        public string nome_do_jogo { get; set; }
        public string horas_para_zerar { get; set; }
        public string genero_do_jogo { get; set; }
        public string ano_de_lancamento { get; set; }
    }
}
