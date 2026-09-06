using LearningMVCApp.Models;

namespace LearningMVCApp.Repository
{
    public interface ICourseService
    {
        List<MasterCourse> GetAllMasterCourses();
        List<SubCourse> GetAllSubCourses();
    }
}
