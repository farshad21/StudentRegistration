// DataAccess/Repository/StudentRepository.cs
using Dapper;
using DataAccess.Models;
using System.Data;
using DataAccess.Interface;
using DataAccess.DataContext;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperDbContext _context;

        public StudentRepository(DapperDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var sql = "INSERT INTO Students (FirstName, LastName, NationalCode, BirthYear, StudentCode) " +
                          "VALUES (@FirstName, @LastName, @NationalCode, @BirthYear, @StudentCode)";

                dbConnection.Execute(sql, student);
            }
        }

        public Student GetById(int id)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Students WHERE Id = @Id";
                return dbConnection.QuerySingleOrDefault<Student>(sql, new { Id = id });
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Students";
                return dbConnection.Query<Student>(sql);
            }
        }

        public void Update(Student student)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var sql = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, " +
                          "NationalCode = @NationalCode, BirthYear = @BirthYear, StudentCode = @StudentCode " +
                          "WHERE Id = @Id";

                dbConnection.Execute(sql, student);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                var sql = "DELETE FROM Students WHERE Id = @Id";
                dbConnection.Execute(sql, new { Id = id });
            }
        }
    }
}
