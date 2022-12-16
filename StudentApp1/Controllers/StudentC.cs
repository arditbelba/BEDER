using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentC : ControllerBase
{
 
    static List<Student> Students = new()
    {
       new Student
       {
           Id = 1,
           DateCreated = DateTime.Today,
           DateUpdted = DateTime.Today,
           DateOfBirth = DateTime.Today.AddYears(-70),
           FirstName = "John",
           LastName = "Cena",
           GraduationYear = 1988,
       },
       new Student
       {
           Id = 2,
           DateCreated = DateTime.Today,
           DateUpdted = DateTime.Today,
           DateOfBirth = DateTime.Today.AddYears(-50),
           FirstName = "Rey",
           LastName = "Misteryo",
           GraduationYear = 1990,
       }
    };


    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        student.Id = Students.Count + 1;
        student.DateCreated = DateTime.Today;

        Students.Add(student);
        return Ok("Student added");
    }

    [HttpPut]
    public IActionResult Put([FromBody] Student student)
    {
        if (student.Id > Students.Count)
            return NotFound("Student not found!");

        if (student.DateUpdted != student.DateCreated)
            return NotFound("Student can't be updated");


        student.DateUpdted = DateTime.Today;
        Students[student.Id - 1] = student;
        return Ok("Student updated");
    }
}