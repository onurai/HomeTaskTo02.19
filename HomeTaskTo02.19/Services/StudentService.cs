using HomeTaskTo02._19.Data.Context;
using HomeTaskTo02._19.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo02._19.Services
{
    public class StudentService : IStudentService
    {
        private readonly MainDbContext _dbase;

        public StudentService(MainDbContext studentDbContext)
        {
            _dbase = studentDbContext;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _dbase.Students.ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            var existedStudent = await _dbase.Students.FirstOrDefaultAsync(x => x.Id == id);
            return existedStudent;
        }

        public async Task<Student> Create(Student student)
        {
            await _dbase.Students.AddAsync(student);
            await _dbase.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(int id, Student student)
        {
            var existedStudent = await _dbase.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existedStudent == null) throw new Exception();
            existedStudent.Name = student.Name;
            existedStudent.Surname = student.Surname;
            existedStudent.Class = student.Class;

            await _dbase.SaveChangesAsync();
            return existedStudent;
        }

        public async Task Remove(int id)
        {
            var existedStudent = await _dbase.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existedStudent == null) throw new Exception();
            _dbase.Students.Remove(existedStudent);
            await _dbase.SaveChangesAsync();
        }


    }
}
