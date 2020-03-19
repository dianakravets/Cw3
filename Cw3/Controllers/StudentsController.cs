using System;
using System.Collections.Generic;
using System.Linq;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        // GET
        [HttpGet]
     //   public string GetStudent()
     //   {
     //       return "Kowalski, Malewski, Andrzejewski";
      //  }
         public OkObjectResult GetStudent(string orderBy)
       {
           // return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
           return Ok(_dbService.GetStudents());
       }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2){
                return Ok("Malewski");
        }
            

        return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumer = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id,Student student)
        {
            student.LastName = "Kta";
            return Ok("Aktualizacja dokonczona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
         MockDbService mock=new MockDbService();
         List<Student> studs = mock.GetStudents().ToList();
         studs.Remove(studs.Find(s=>s.IdStudent==id));

            return Ok("Usuwanie ukonczone");
        }

        
    }
}