using LearningMVCApp.Data;
using LearningMVCApp.Models;
using Microsoft.EntityFrameworkCore;
using LearningMVCApp.Repository;

namespace LearningMVCApp.Service
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext cs;
        public CourseService(ApplicationDbContext cs)
        {
            this.cs = cs;
        }
        public List<MasterCourse> GetAllMasterCourses()
        {
            return cs.MasterCourses.ToList();
        }
        public List<SubCourse> GetAllSubCourses()
        {
            return cs.SubCourses.ToList();
        }
    }
}
