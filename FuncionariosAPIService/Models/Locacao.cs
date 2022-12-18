using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    [Table("Locacao")]
    public class Locacao
    {
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime? DataDevolvido { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Filme")]
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        [MaxLength(1)]
        public string RegAtivo { get; set; } = "S";

        public StatusLocacao StatusLocacao { get; set; }

    }
}