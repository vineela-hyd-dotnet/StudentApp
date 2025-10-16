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
                var student = _studentService.GetStudentById(id);
                if (student == null)
                    throw new Exception($"Student with ID {id} not found.");

                return View(student);
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
                if (ModelState.IsValid)
                {
                    _studentService.AddStudent(student);
                    return RedirectToAction(nameof(Index));
                }
                return View(student);
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
                if (id != student.StudentId)
                    throw new Exception("ID mismatch between route and student data.");

                if (ModelState.IsValid)
                {
                    _studentService.UpdateStudent(student);
                    return RedirectToAction(nameof(Index));
                }

                return View(student);
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
                var deletedStudent = _studentService.DeleteStudent(id);
                if (deletedStudent == null)
                    throw new Exception($"Student with ID {id} not found for deletion.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting student: " + ex.Message);
            }
        }
    }
}
