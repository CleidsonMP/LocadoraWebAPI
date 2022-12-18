using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Locadora.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int Id { get; set; }
       
        [MaxLength(14)]
        public string CPF { get; set; }
        public string Nome { get; set; }
        [MaxLength(14)]
        public string Telefone { get; set; }
        [MaxLength(1)]
        public string RegAtivo { get; set; } = "S";
    }
}