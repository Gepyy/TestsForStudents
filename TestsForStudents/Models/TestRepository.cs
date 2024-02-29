namespace TestsForStudents.Models
{
    public class TestRepository : ITestRepository
    {
        private readonly List<Test> _tests;

        public TestRepository()
        {
            _tests = new List<Test>
            {
                new Test { Id = 1, Title = "Test 1", Description = "Description for Test 1" },
                new Test { Id = 2, Title = "Test 2", Description = "Description for Test 2" },
            };
        }

        public IEnumerable<Test> GetTests()
        {
            return _tests;
        }

        public Test GetTestById(int id)
        {
            return _tests.FirstOrDefault(t => t.Id == id);
        }

        public void AddTest(Test test)
        {
            test.Id = _tests.Count + 1;
            _tests.Add(test);
        }

        public void UpdateTest(Test test)
        {
            var index = _tests.FindIndex(t => t.Id == test.Id);
            if (index != -1)
            {
                _tests[index] = test;
            }
        }

        public void DeleteTest(Test test)
        {
            _tests.Remove(test);
        }
    }
}
