namespace DataAccess.Models
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public int BirthYear { get; private set; }
        public string StudentCode { get; private set; }

        public Student(string firstName, string lastName, string nationalCode, int birthYear)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            BirthYear = birthYear;
            StudentCode = GenerateStudentCode();
        }

        private string GenerateStudentCode()
        {
            // اینجا باید کدی بنویسیم که یک کد دانشجویی یونیک ۱۰ رقمی تولید کند.
            // برای سادگی فعلاً یک کد ثابت برمی‌گردانیم.
            return "1234567890";
        }
    }
}
