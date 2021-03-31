using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvpConfDemos.MvcCore.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool ClienteEspecial { get; set; }
        public string NomeDaMae { get; set; }
        public byte QuantidadeFilhos { get; set; }
    }
}
