using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioToro.Application.DTO
{
    public class BuyOrderDto
    {
        public string UserAccount { get; set; }
        public string OrderName { get; set; }
        public int OrderAmount { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
    }
}
