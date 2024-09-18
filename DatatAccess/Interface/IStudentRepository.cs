// DataAccess/Interface/IStudentRepository.cs
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interface
{
    public interface IStudentRepository
    {
        void Add(Student student);
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        void Update(Student student);
        void Delete(int id);
    }
}
