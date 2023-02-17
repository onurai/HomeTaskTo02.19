
using HomeTaskTo02._19.Data.Entities;

namespace HomeTaskTo02._19.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> Get(int id);
        Task<Student> Create(Student student);
        Task<Student> Update(int id, Student student);
        Task Remove(int id);
    }
}
