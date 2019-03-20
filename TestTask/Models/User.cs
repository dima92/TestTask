using System;

namespace TestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirthday { get; set; }
        public int NumberLicense { get; set; }
    }
}
