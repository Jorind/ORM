using HelloEF.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HelloEF {
    public class SchoolService {

        protected readonly SchoolContext _dbContext;
      
        public SchoolService(SchoolContext context)
        {
            _dbContext = context;
        }

        public List<Student> GetAllStudents()
        {
          var stds =  _dbContext.Students;
            var result = stds.ToList();


          return result;
        }

        public List<Student> GetStudentWithMoreThan10YearsOfExp()
        {
          var stds =  _dbContext.Students;
          var result = stds.Where(p=>p.YearsOfExperience>10);

          return result.ToList();
        }
        
        public List<Student> GetStudentDepartmentName(int studentId)
        {

        var students =  _dbContext.Students                    
                .Where(p=>p.Id==studentId).ToList();

        Student std = students[0]; 
        //_dbContext.Entry(std).Reference(usr => usr.Department).Load(); 

        var departmentName =std.Department.Name;
         
        var departmentStudents =std.Department.Students;

        var std1Dep = departmentStudents.First().Department.Name;
        var std2Dep = departmentStudents.Where(p=>p.Id==9).First().Department.Name;

        //var studentFirstProjects = std.Projects.First();

        //_dbContext.Entry(std).Collection(s => s.Projects).Load();
        //var project = std.Projects.FirstOrDefault();

        var stdProjs= std.ProjectStudents.Select(s=>s.Project).ToList();

        var studentsOfProjects = stdProjs.Select(s=>s.ProjectStudents).ToList();



        //Console.WriteLine($"Dpt name is: {departmentName} and first proj name is {project.Name}");

        var withInclude = _dbContext.Students
                            .Include(i => i.Department)
                        .Where(p => p.Id == studentId && p.DepartmentId.HasValue)
                        .ToList();


            return null;
        }
    }
}
