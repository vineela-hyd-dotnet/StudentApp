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
           return _repo.GetAllStudents();
        }

        public Student GetStudentById(int studentId)
        {
            return _repo.GetStudentById(studentId);
        }

        public Student AddStudent(Student student)
        {
           return _repo.AddStudent(student);
        }

        public Student UpdateStudent(Student student)
        {
           return _repo.UpdateStudent(student);
        }

        public Student DeleteStudent(int studentId)
        {
            return _repo.DeleteStudent(studentId);
        }
    }
}


