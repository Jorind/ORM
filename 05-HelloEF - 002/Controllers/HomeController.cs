using HelloEF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HelloEF.ChangeTrackerExample;

namespace HelloEF.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        protected readonly SchoolContext _dbContext;

        public HomeController(ILogger<HomeController> logger, SchoolContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //var schoolService = new SchoolService(_dbContext);
            //var students = schoolService.GetStudentDepartmentName(6);

            //Example.SqlServerTypeMapper(_dbContext);
            //Example.RawSql(_dbContext);
            //Example.ReadNUpdateEntry(_dbContext);
            //Example.UpdateEntry(_dbContext);
            //Example.SqlServerTypeMapper(_dbContext);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}