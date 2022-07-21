using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Entity
{
    [Table("Games")]
    public class GameEntity
    {
        [Key]
        public int COD_GAME { get; set; }
        public string NOME_GAME { get; set; }
        public string HORAS_ZERAR { get; set; }
        public string GENERO_GAME { get; set; }
        public string ANO_LANCAMENTO { get; set; }
        public DateTime? DATA_REGISTRO { get; set; }
    }
}
