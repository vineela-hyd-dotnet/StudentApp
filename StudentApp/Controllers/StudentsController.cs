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
                ViewBag.ErrorMessage = "Error fetching students: " + ex.Message;
                return View("Error");
            }
        }

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                    return NotFound();

                return View(student);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error fetching student details: " + ex.Message;
                return View("Error");
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
                    TempData["SuccessMessage"] = "Student added successfully!";
                    return RedirectToAction(nameof(Index));
                }
                return View(student);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error creating student: " + ex.Message;
                return View("Error");
            }
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                    return NotFound();

                return View(student);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error loading edit form: " + ex.Message;
                return View("Error");
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
                    return BadRequest();

                if (ModelState.IsValid)
                {
                    _studentService.UpdateStudent(student);
                    TempData["SuccessMessage"] = "Student updated successfully!";
                    return RedirectToAction(nameof(Index));
                }

                return View(student);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error updating student: " + ex.Message;
                return View("Error");
            }
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                    return NotFound();

                return View(student);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error loading delete confirmation: " + ex.Message;
                return View("Error");
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
                    return NotFound();

                TempData["SuccessMessage"] = "Student deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error deleting student: " + ex.Message;
                return View("Error");
            }
        }
    }
}
