﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Model.EmployeeAggregate
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; private set; }
        public int age { get; private set; }
        public string? photo { get; private set; }

        public Employee(string name, int age, string photo)
        {
            this.name = name;
            this.age = age;
            this.photo = photo;
        }
        public Employee() { }
    }
}
