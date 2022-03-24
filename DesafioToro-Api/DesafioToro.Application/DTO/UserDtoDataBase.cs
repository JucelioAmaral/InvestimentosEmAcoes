using DesafioToro.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioToro.Application.DTO
{
    public class UserDtoDataBase
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public int TrendId { get; set; }        
        public int AmountOrder { get; set; }
    }
}
