using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokeProjeto.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}