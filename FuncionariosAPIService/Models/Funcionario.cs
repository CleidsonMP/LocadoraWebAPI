using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Index(IsUnique = true)]
        public int CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public int Salario { get; set; }
        public string Setor { get; set; }
    }
}