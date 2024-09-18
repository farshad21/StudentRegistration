// Service/Interface/IStudentService.cs
using DataAccess.Models;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IStudentService
    {
        // ثبت دانشجوی جدید
        void RegisterStudent(string firstName, string lastName, string nationalCode, int birthYear);

        // دریافت دانشجو بر اساس ID
        Student GetStudentById(int id);

        // دریافت همه دانشجویان
        IEnumerable<Student> GetAllStudents();

        // به‌روزرسانی اطلاعات دانشجو
        void UpdateStudent(Student student);

        // حذف دانشجو بر اساس ID
        void DeleteStudent(int id);
    }
}
