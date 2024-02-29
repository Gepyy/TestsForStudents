using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using TestsForStudents.Models;
using System.IdentityModel.Tokens.Jwt;

namespace UserTestingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController : ControllerBase
    {
        private readonly ITestRepository _repository;

        public TestsController(ITestRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return _repository.GetTests();
        }

        [HttpGet("{id}")]
        public ActionResult<Test> Get(int id)
        {
            var test = _repository.GetTestById(id);
            if (test == null)
            {
                return NotFound();
            }
            return test;
        }

        [HttpPost]
        public ActionResult<Test> Post(Test test)
        {
            _repository.AddTest(test);
            return CreatedAtAction(nameof(Get), new { id = test.Id }, test);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Test test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }
            _repository.UpdateTest(test);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var test = _repository.GetTestById(id);
            if (test == null)
            {
                return NotFound();
            }
            _repository.DeleteTest(test);
            return NoContent();
        }
    }
}
