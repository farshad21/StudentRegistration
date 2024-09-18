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

        [Fact]
        public void GenerateStudentCode_ShouldBeUnique()
        {
            // Arrange
            var firstStudent = new Student("Ali", "Ahmadi", "1234567890", 1995);
            var secondStudent = new Student("Reza", "Mohammadi", "0987654321", 1996);

            // Act
            var firstCode = firstStudent.StudentCode;
            var secondCode = secondStudent.StudentCode;

            // Assert
            Assert.NotEqual(firstCode, secondCode);
            Assert.Equal(10, firstCode.Length);
            Assert.Equal(10, secondCode.Length);
        }

            private static HashSet<string> GeneratedCodes = new HashSet<string>();

        public string FirstName { get; }
        public string LastName { get; }
        public string NationalCode { get; }
        public int BirthYear { get; }
        public string StudentCode { get; }

        private string GenerateStudentCode()
        {
            string code;
            do
            {
                // تولید یک کد ۱۰ رقمی تصادفی
                code = new Random().Next(1000000000, int.MaxValue).ToString().PadLeft(10, '0').Substring(0, 10);
            } while (GeneratedCodes.Contains(code));

            GeneratedCodes.Add(code);
            return code;
        }

        [Theory]
        [InlineData("", "Ahmadi", "1234567890", 1995)]
        [InlineData("Ali", "", "1234567890", 1995)]
        [InlineData("Ali", "Ahmadi", "", 1995)]
        public void CreateStudent_WithInvalidData_ShouldThrowArgumentException(string firstName, string lastName, string nationalCode, int birthYear)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, nationalCode, birthYear));
        }
    }

}

