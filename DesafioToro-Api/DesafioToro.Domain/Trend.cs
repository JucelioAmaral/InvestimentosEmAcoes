using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DesafioToro.Domain
{
    public class Trend
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrendId { get; set; }
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
    }
}
