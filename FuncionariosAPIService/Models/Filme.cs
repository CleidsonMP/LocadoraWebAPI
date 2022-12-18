using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    [Table("Filme")]
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Categoria { get; set; }
        [MaxLength(1)]
        public string RegAtivo { get; set; } = "S";

        [MaxLength(1)]
        public string Disponivel { get; set; } = "S";
    }
}