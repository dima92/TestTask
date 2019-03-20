using System;
using System.Collections.Generic;

namespace TestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirthday { get; set; }
        public int NumberLicense { get; set; }
        public List<Order> Order { get; set; }
    }
}
