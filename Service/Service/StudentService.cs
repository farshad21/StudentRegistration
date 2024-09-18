// Service/Service/StudentService.cs
using DataAccess.Models;
using DataAccess.Repository;
using DataAccess.Interface;
using Service.Interface;

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
            // ایجاد شیء دانشجو
            var student = new Student(firstName, lastName, nationalCode, birthYear);

            // ثبت دانشجو در دیتابیس
            _studentRepository.Add(student);
        }
    }
}
