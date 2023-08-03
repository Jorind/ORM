using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloEF.DomainModels {
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string FirstName { get; set; } =string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;

        //[NotMapped]
        //Props only with getters(without setters) are not mapped automatically.
        public string FullName => $"{FirstName} {LastName}";

        public int? Age { get; set; }
        public int YearsOfExperience { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal AverageSalary { get; set; }

        //public LevelOfExpertise LevelOfExpertise { get; } = LevelOfExpertise.Intership;
        public LevelOfExpertise LevelOfExpertise { get; set; }

        //[NotMapped]
        public string Address { get; set; } = string.Empty;

        //FK to Departments
        public int? DepartmentId { get; set; }

        //public byte[] LastUpdate { get; set; }

        //Navigation property
        public virtual Department? Department { get; set; }

        public virtual ICollection<ProjectStudent> ProjectStudents { get; set; } = new List<ProjectStudent>();
    }
}

