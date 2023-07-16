using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloEF.DomainModels {
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; } =string.Empty;

        public string Subject { get; set; }

        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public int? Age { get; set; }

        public int YearsOfExperience { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal AverageSalary { get; set; }

        public LevelOfExpertise LevelOfExpertise { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }
    }
}

