using Xunit;
using DataAccess.Models;

namespace Test.UnitTests
{
    public class StudentTests
    {
        [Fact]
        public void CreateStudent_WithValidData_ShouldCreateStudentObject()
        {
            // Arrange
            var firstName = "Ali";
            var lastName = "Ahmadi";
            var nationalCode = "1234567890";
            var birthYear = 1995;

            // Act
            var student = new Student(firstName, lastName, nationalCode, birthYear);

            // Assert
            Assert.NotNull(student);
            Assert.Equal(firstName, student.FirstName);
            Assert.Equal(lastName, student.LastName);
            Assert.Equal(nationalCode, student.NationalCode);
            Assert.Equal(birthYear, student.BirthYear);
            Assert.NotNull(student.StudentCode);
            Assert.Equal(10, student.StudentCode.Length);
        }
    }
}
