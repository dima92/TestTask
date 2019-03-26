using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.ModelsDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public bool Rent { get; set; } //add chexbox
        public string Description { get; set; } //add 
        public DateTime StartDate { get; set; } //add datePiker
        public DateTime EndDate { get; set; } //add datePiker
        public int CarId { get; set; } // внешний ключ  add id car
        public string Car { get; set; }  // навигационное свойство
        public int UserId { get; set; } // внешний ключ  add id user
        public string User { get; set; }  // навигационное свойство
    }
}
