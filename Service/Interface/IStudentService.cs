// Service/Interfaces/IStudentService.cs
namespace Service.Interface
{
    public interface IStudentService
    {
        void RegisterStudent(string firstName, string lastName, string nationalCode, int birthYear);
    }
}
