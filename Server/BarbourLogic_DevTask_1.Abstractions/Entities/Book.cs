using System;
using System.Collections.Generic;
using System.Text;

namespace BarbourLogic_DevTask_1.Abstractions.Entities
{
    public class Book
    {
        public string Id{ get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
    }
}
