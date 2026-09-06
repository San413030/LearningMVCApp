using LearningPlatform.Data;
using LearningPlatform.Models;
using LearningPlatform.Repository;
using LearningPlatform.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LearningPlatform.Controllers
{
    public class MasterCourseController : Controller
    {

        private readonly IMasterCourseRepository service;

        public MasterCourseController(IMasterCourseRepository service)
        {
            this.service = service;
        }

        public IActionResult Create(MasterCourse course, IFormFile ThumbnailFile)
        {
            if (ThumbnailFile == null)
            {
                return Content("Please select thumbnail.");
            }

            string path = "wwwroot/uploads/" + ThumbnailFile.FileName;

            ThumbnailFile.CopyTo(new FileStream(path, FileMode.Create));

            course.Thumbnail = "/uploads/" + ThumbnailFile.FileName;


            service.AddMasterCourse(course);

            TempData["msg"] = "MasterCourse Added Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var data = service.GetMasterCourses();

            return View(data);
        }

      
       public IActionResult UpdateData(MasterCourse course, IFormFile ThumbnailFile)

        {
            var oldData = service.GetById(course.MasterCourseId);

            if(oldData == null)
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

                course.Thumbnail = oldData.Thumbnail;
            }

            service.UpdateMasterCourse(course);

            TempData["msg"] = "MasterCourse Updated Successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            service.DeleteMasterCourse(id);

            TempData["Msg"] = "Data Deleted Successfully";

            return RedirectToAction("Index");

        }
    }
}
