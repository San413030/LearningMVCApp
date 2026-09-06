using Microsoft.AspNetCore.Mvc;
using LearningMVCApp.Repository;
using LearningMVCApp.Models;

namespace LearningMVCApp.Controllers
{
    public class AllCoursesController : Controller
    {
        private readonly ICourseService cs;

        public AllCoursesController(ICourseService cs)
        {
            this.cs = cs;
        }
        public IActionResult Index()
        {
            var masterCourses = cs.GetAllMasterCourses();
            var subCourses = cs.GetAllSubCourses();

            var viewModel = new AllCoursesViewModel
            {
                MasterCourses = masterCourses,
                SubCourses = subCourses
            };
            return View(viewModel);
        }
    }
}
