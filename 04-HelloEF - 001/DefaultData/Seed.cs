using System.Numerics;
using HelloEF.DomainModels;

namespace HelloEF.DefaultData
{
    public class Seed 
    {
        public static async Task SeedData(SchoolContext context)
        {
            Student firstStudent = new(), secondStudent, thirdStudent;

            if (!context.Students.Any())
            {
                await context.AddRangeAsync(new[] {
                    firstStudent=new Student(){
                        FirstName = "Jorind",
                        Age=30,
                        AverageSalary=1234,
                        LastName="Plasa",
                        LevelOfExpertise=LevelOfExpertise.TeamLead,
                        YearsOfExperience=10,
                        Address="Shkolla Edit Durham"
                    },
                });
  
                await context.SaveChangesAsync();
            }
        }
    }
}
