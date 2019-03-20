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
    }
}
