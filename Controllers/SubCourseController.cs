using LearningPlatform.Data;
using LearningPlatform.Models;
using LearningPlatform.Repository;
using Microsoft.AspNetCore.Mvc;


namespace LearningPlatform.Controllers
{
    public class SubCourseController : Controller
    {
        private readonly ISubCourseRepository service;

        public SubCourseController(ISubCourseRepository service)
        {
            this.service = service;
        }
 
        public IActionResult Create(SubCourse course,  IFormFile ThumbnailFile)
        {
            if(ThumbnailFile == null)
            {
                return Content("Please Selected Thumbnail");
            }


            string path = "wwwroot/uploads/" + ThumbnailFile.FileName;

            ThumbnailFile.CopyTo(new FileStream(path, FileMode.Create));

            course.Thumbnail = "/uploads/" + ThumbnailFile.FileName;

            service.AddSubCourse(course);

            TempData["Msg"] = "Data Added Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var data = service.GetAllSubCourses();

            ViewBag.MasterCourses = service.GetAllMasterCourses();

            return View(data);
        }


        public IActionResult update(SubCourse course, IFormFile ThumbnailFile)
        {
            var find = service.GetSubCourse(course.SubCourseId);

            if (find == null)
            {

                return NotFound();

            }

            if (ThumbnailFile != null)
            {
                string path = "wwwroot/uploads/" + ThumbnailFile.FileName;

                ThumbnailFile.CopyTo(new FileStream(path, FileMode.Create));

                course.Thumbnail = "/uploads/" + ThumbnailFile.FileName;
            }
            else
            {
                course.Thumbnail = find.Thumbnail;
            }

            service.UpdateSubCourse(course);
            TempData["Msg"] = "Data Updated Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            service.DeleteSubCourse(id);

            TempData["Msg"] = "Data Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
