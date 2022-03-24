using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using System;

namespace DesafioToro.Application
{
    public class EventDto
    {
        public string EventName { get; set; }
        public TargetDto Target { get; set; }
        public OriginDto Origin { get; set; }
        public double Amount { get; set; }
    }
}
