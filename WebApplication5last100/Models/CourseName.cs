using System;
using System.Collections.Generic;

namespace WebApplication5last100.Models
{
    public partial class CourseName
    {
        public CourseName()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
