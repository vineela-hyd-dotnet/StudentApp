using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.Services;
using System;

namespace StudentApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentSevice _studentService;

        public StudentsController(IStudentSevice studentService)
        {
            _studentService = studentService;
        }

        // GET: Students
        public IActionResult Index()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                if (students == null)
                {
                    return NotFound();
                }
                return View(students);
            }
           
            catch (Exception ex)
            {
                throw new Exception("Error fetching student list: " + ex.Message);
            }
        }

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var stud = _studentService.GetStudentById(id);
                if (stud == null) {
                    throw new Exception("Id not found");
                }
                return View(stud);
            }
           
            catch (Exception ex)
            {
                throw new Exception("Error fetching student details: " + ex.Message);
            }
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);


                }
               var stud= _studentService.AddStudent(student);
                return RedirectToAction("Index");
                
            }
           
            catch (Exception ex)
            {
                throw new Exception("Error creating student: " + ex.Message);
            }
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                    throw new Exception($"Student with ID {id} not found.");

                return View(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading edit form: " + ex.Message);
            }
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _studentService.UpdateStudent(student);
                return RedirectToAction("Index");

            
            
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student: " + ex.Message);
            }
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                    throw new Exception($"Student with ID {id} not found.");

                return View(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading delete confirmation: " + ex.Message);
            }
        }

        // POST: Students/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var stud = _studentService.DeleteStudent(id);
               
                return RedirectToAction("Index");

            }
          
            catch (Exception ex)
            {
                throw new Exception("Error deleting student: " + ex.Message);
            }
        }
    }
}
