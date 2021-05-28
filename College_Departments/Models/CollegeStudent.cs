using System;
using System.Collections.Generic;

#nullable disable

namespace College_Departments
{
    public partial class CollegeStudent
    {
        public int StudentId { get; set; }
        public string StudentsName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public int? StudentsAge { get; set; }
        public int? Height { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int? Roll { get; set; }
    }
}
