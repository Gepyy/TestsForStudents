using static System.Net.Mime.MediaTypeNames;

namespace TestsForStudents.Models
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetTests();
        Test GetTestById(int id);
        void AddTest(Test test);
        void UpdateTest(Test test);
        void DeleteTest(Test test);
    }
}
