using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using webapplication1.Models;

namespace webapplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return CollegeRepository.Students;
        }
        [HttpDelete("{id:int}", Name="DeletingStudentById")]
        public ActionResult<bool> DeleteStudentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var st=CollegeRepository.Students.Where(x => x.Id == id).FirstOrDefault();
            if (st == null)
            {
                return NotFound("Student not found");
            }
            CollegeRepository.Students.Remove(st);
            return Ok(true);
        }
        [HttpPost]
        [Route("create")]
        public ActionResult<Student> CreateStudent(Student model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            int newid = CollegeRepository.Students.LastOrDefault().Id + 1;
            Student student = new Student {
                Id = newid,
                Studentname = model.Studentname,
                email = model.email,
                Address=model.Address,
                city=model.city

            };
            CollegeRepository.Students.Add(student);
            model.Id = student.Id;
            return Ok(model);


        }
    }
}
