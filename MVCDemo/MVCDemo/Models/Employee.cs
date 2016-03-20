using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCDemo.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}