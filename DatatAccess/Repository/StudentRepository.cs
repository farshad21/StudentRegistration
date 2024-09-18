// DataAccess/Repository/StudentRepository.cs
using Dapper;
using DataAccess.Models;
using System.Data;
using DataAccess.Interface;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _dbConnection;

        public StudentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Student student)
        {
            var sql = "INSERT INTO Students (FirstName, LastName, NationalCode, BirthYear, StudentCode) " +
                      "VALUES (@FirstName, @LastName, @NationalCode, @BirthYear, @StudentCode)";

            _dbConnection.Execute(sql, student);
        }

        public Student GetById(int id)
        {
            var sql = "SELECT * FROM Students WHERE Id = @Id";
            return _dbConnection.QuerySingleOrDefault<Student>(sql, new { Id = id });
        }

        public IEnumerable<Student> GetAll()
        {
            var sql = "SELECT * FROM Students";
            return _dbConnection.Query<Student>(sql);
        }

        public void Update(Student student)
        {
            var sql = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, " +
                      "NationalCode = @NationalCode, BirthYear = @BirthYear, StudentCode = @StudentCode " +
                      "WHERE Id = @Id";

            _dbConnection.Execute(sql, student);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Students WHERE Id = @Id";
            _dbConnection.Execute(sql, new { Id = id });
        }
    }
}
