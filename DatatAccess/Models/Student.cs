namespace DataAccess.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public int BirthYear { get; private set; }
        public string StudentCode { get; private set; }

        public Student(string firstName, string lastName, string nationalCode, int birthYear)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name is required.");
            if (string.IsNullOrWhiteSpace(nationalCode)) throw new ArgumentException("National code is required.");
            if (birthYear <= 0) throw new ArgumentException("Birth year must be greater than zero.");

            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            BirthYear = birthYear;
            StudentCode = GenerateStudentCode();
        }

        private string? GenerateStudentCode()
        {
            throw new NotImplementedException();
        }
    }
}
