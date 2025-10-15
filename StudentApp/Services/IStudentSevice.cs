using StudentApp.Models;

namespace StudentApp.Services
{
    public interface IStudentSevice
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student DeleteStudent(int studentId);
    }
}
