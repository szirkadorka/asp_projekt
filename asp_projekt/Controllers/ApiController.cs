using asp_projekt.TextbookModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp_projekt.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("student/all")]
        public IActionResult Studentall()
        {
            TextbookSupportContext context = new TextbookSupportContext();
            var student = from x in context.Students
                        select x;

            return Ok(student);
        }

        [HttpGet]
        [Route("student/{id}")]
        public IActionResult Studentid(int id)
        {
            TextbookSupportContext context = new TextbookSupportContext();
            var student = (from x in context.Students
                            where x.StudentId == id
                            select x).FirstOrDefault();

            return Ok(student);
        }

        [HttpGet]
        [Route("textbook/{id}")]
        public IActionResult Textbookid(int id)
        {
            TextbookSupportContext context = new TextbookSupportContext();
            var textbook = (from x in context.Textbooks
                            where x.TextbookId == id
                            select x).FirstOrDefault();

            return Ok(textbook);
        }

        [HttpPost]
        [Route("student/add")]
        public void Post([FromBody] TextbookModels.Student newstudent)
        {
            TextbookSupportContext context = new TextbookSupportContext();
            context.Students.Add(newstudent);
            context.SaveChanges();
        }

        [HttpDelete]
        [Route("student/delete/{id}")]
        public void Delete(int id)
        {
            TextbookSupportContext context = new TextbookSupportContext();
            var studentToBeDeleted = (from x in context.Students
                                      where x.StudentId == id
                                      select x).FirstOrDefault();

            context.Students.Remove(studentToBeDeleted);
            context.SaveChanges();
        }

    }
}
