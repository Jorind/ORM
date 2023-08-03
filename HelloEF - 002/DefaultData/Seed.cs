using System.Numerics;
using HelloEF.DomainModels;

namespace HelloEF.DefaultData
{
    public class Seed 
    {
        public static async Task SeedData(SchoolContext context)
        {
            Department IT = new(), Finance = new();
            Student firstStudent = new(), secondStudent, thirdStudent;

            if (!context.Departments.Any())
            {
                await context.AddRangeAsync(new[] {
                    IT=new Department(){Name="IT Department" },
                    Finance=new Department(){Name= "Finance Department" },
                });
                await context.SaveChangesAsync();
            }

            if (!context.Students.Any())
            {
                await context.AddRangeAsync(new[] {
                    firstStudent=new Student(){
                        FirstName = "Jorind",
                        Age=30,
                        AverageSalary=1234,
                        Department = IT,
                        LastName="Plasa",
                        LevelOfExpertise=LevelOfExpertise.TeamLead,
                        YearsOfExperience=10,
                        Address="Shkolla Edit Durham"
                    },
                });
  
                await context.SaveChangesAsync();
            }

            //if (!context.Projects.Any())
            //{
            //    await context.AddRangeAsync(new[] {
            //        new Project(){
            //            Name="Learning C# by SDA",
            //            Description="Learn the basics of C# programing",
            //            IsPrivate =true,
            //            Students=new List<Student>{firstStudent}
            //        },
            //    });
            //    await context.SaveChangesAsync();
            //}
        }
    }
}
