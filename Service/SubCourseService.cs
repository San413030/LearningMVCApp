using LearningPlatform.Data;
using LearningPlatform.Models;
using LearningPlatform.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LearningPlatform.Service
{
    public class SubCourseService : ISubCourseRepository
    {
        private readonly ApplicationDbContext data;
        public SubCourseService(ApplicationDbContext context)
        { 
            data = context;
        }

        public void AddSubCourse(SubCourse course)
        {
            data.SubCourses.Add(course);

            data.SaveChanges();
        }

        public void DeleteSubCourse(int id)
        {
            var deletedata = data.SubCourses.Find(id);

            data.SubCourses.Remove(deletedata);

            data.SaveChanges();
        }

        public List<MasterCourse> GetAllMasterCourses()
        {
            var course = data.MasterCourses.ToList();

            return course;
        }

        public List<SubCourse> GetAllSubCourses()
        {
            var info = data.SubCourses.ToList();

            return info;
        }

        public SubCourse GetSubCourse(int id)
        {
            var GetById = data.SubCourses.Find(id);

            return GetById;
        }

        public void UpdateSubCourse(SubCourse course)
        {
            var oldData = data.SubCourses.Find(course.SubCourseId);

            if (oldData != null)
            {

                oldData.MasterCourseId = course.MasterCourseId;
                oldData.SubCourseName = course.SubCourseName;
                oldData.Amount = course.Amount;
                oldData.Thumbnail = course.Thumbnail;
                oldData.Status = course.Status;
            }

            data.SaveChanges();

        }
    }
}
