using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DesafioToro.Domain
{
    public class Target
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TargetId { get; set; }
        public string Bank { get; set; }  // Banco Toro "352",
        public string Branch { get; set; } // Única agenda, sempre 0001
        public string Account { get; set; }  // Conta do usuário na Toro (unica por usuário)
    }
}
