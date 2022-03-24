using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioToro.Domain
{
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EventName { get; set; }
        public int? TargetId { get; set; }
        public Target Target { get; set; }
        public int? OriginId { get; set; }
        public Origin Origin { get; set; }
        public double Amount { get; set; }        
    }
}
