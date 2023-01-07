using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5last100.Models
{
    public partial class Student
    {


        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        [RegularExpression(@"^[0-9]{8}", ErrorMessage = "Value is not correct")]

        public int PhoneNum { get; set; }
        [RegularExpression(@"^[A-Za-z]{2}[0-9]{5}", ErrorMessage = "Value is not correct")]
        public string MatNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^[1-5]{1}", ErrorMessage = "Value is not correct")]

        public int CourseNumb { get; set; }
        public int? CourseNameId { get; set; }

        public virtual CourseName? CourseName { get; set; }
    }
}
