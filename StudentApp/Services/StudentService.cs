using StudentApp.Models;
using StudentApp.Repo;

namespace StudentApp.Services
{
    public class StudentService:IStudentSevice
    {
        private readonly IStudentRepo _repo;

        public StudentService(IStudentRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return _repo.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching students list", ex);
            }
        }

        public Student GetStudentById(int studentId)
        {
            try
            {
                return _repo.GetStudentById(studentId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student by ID", ex);
            }
        }

        public Student AddStudent(Student student)
        {
            try
            {
                return _repo.AddStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding new student", ex);
            }
        }

        public Student UpdateStudent(Student student)
        {
            try
            {
                return _repo.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student details", ex);
            }
        }

        public Student DeleteStudent(int studentId)
        {
            try
            {
                return _repo.DeleteStudent(studentId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting student", ex);
            }
        }
    }
}


