using System;

namespace TestTask.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool Rent { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; } // внешний ключ
        public Car Car { get; set; }  // навигационное свойство
        public int UserId { get; set; } // внешний ключ
        public User User { get; set; }  // навигационное свойство
    }
}
