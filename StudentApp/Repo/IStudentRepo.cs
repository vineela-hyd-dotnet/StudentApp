using StudentApp.Models;

namespace StudentApp.Repo
{
    public interface IStudentRepo
    {
 
            IEnumerable<Student> GetAllStudents();
            Student GetStudentById(int studentId);
            Student AddStudent(Student student);
            Student UpdateStudent(Student student);
            Student DeleteStudent(int studentId);
        }
    }


