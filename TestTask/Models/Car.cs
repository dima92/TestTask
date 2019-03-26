using System;
using System.Collections.Generic;

namespace TestTask.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string ClassCar { get; set; }
        public DateTime DateManufacture { get; set; }
        public string NumberRegistration { get; set; }
        public List<Order> Order { get; set; }
    }
}
