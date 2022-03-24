using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DesafioToro.Domain
{
    public class Origin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OriginId { get; set; }
        public string Bank { get; set; } // Banco de origem "033"
        public string Branch { get; set; } // Agencia de origem "03312"
        public string CPF { get; set; } //"45358996060"  CPF do remetente
    }
}
