using LearningPlatform.Models;

namespace LearningPlatform.Repository
{
    public interface IMasterCourseRepository
    {

        void AddMasterCourse(MasterCourse course);

        List<MasterCourse> GetMasterCourses();

        MasterCourse GetById(int id);

        void UpdateMasterCourse(MasterCourse course);

        void DeleteMasterCourse(int id);

   
    }
}
