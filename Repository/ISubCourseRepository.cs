using LearningPlatform.Models;

namespace LearningPlatform.Repository
{
    public interface ISubCourseRepository
    {
        void AddSubCourse(SubCourse course);

        List<SubCourse> GetAllSubCourses();

        SubCourse GetSubCourse(int id);

        void UpdateSubCourse(SubCourse course);

        void DeleteSubCourse(int id);

        List<MasterCourse> GetAllMasterCourses();

    }
}
