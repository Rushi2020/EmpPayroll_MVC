using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer
{
    public class UserModel
    {
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
        
        
    }
}
