using LearningPlatform.Data;
using LearningPlatform.Models;
using LearningPlatform.Repository;

namespace LearningPlatform.Service
{
    public class MasterCourseService : IMasterCourseRepository
    {
        private readonly ApplicationDbContext data;
        public MasterCourseService(ApplicationDbContext context) { 
        
            data=context;
        }

        public void AddMasterCourse(MasterCourse course)
        {
             data.MasterCourses.Add(course);

            data.SaveChanges();


        }

        public void DeleteMasterCourse(int id)
        {
            var IdData = data.MasterCourses.Find(id);

            if (IdData != null)
            {
                data.MasterCourses.Remove(IdData);

            }

            data.SaveChanges();
        }

        public MasterCourse GetById(int id)
        {
            var IdData = data.MasterCourses.Find(id);

            return IdData;
        }

        public List<MasterCourse> GetMasterCourses()
        {
            var course = data.MasterCourses.ToList();

            return course;
        }

        public void UpdateMasterCourse(MasterCourse course)
        {
            var oldData = data.MasterCourses.Find(course.MasterCourseId);

            if(oldData != null)
            {
                oldData.MasterCourseName = course.MasterCourseName;
                oldData.Status = course.Status;
                oldData.Thumbnail = course.Thumbnail;

            }
            data.SaveChanges();
        }
    }
}
