// Service/Service/StudentService.cs
using DataAccess.Interface;
using DataAccess.Models;
using Service.Interface;
using System.Collections.Generic;

namespace Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void RegisterStudent(string firstName, string lastName, string nationalCode, int birthYear)
        {
            var student = new Student(firstName, lastName, nationalCode, birthYear);
            _studentRepository.Add(student);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}
