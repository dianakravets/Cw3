
using System.Collections.Generic;
using Cw3.Models;

namespace Cw3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> students;
        private IDbService _dbServiceImplementation;

        static MockDbService()
        {
            students = new List<Student>
            {
                  new Student{IdStudent = 1,FirstName = "Jan",LastName = "Kowalski"},
                  new Student{IdStudent = 2,FirstName = "Anna",LastName = "Malewski"},
                  new Student{IdStudent = 3,FirstName = "Andrzej",LastName = "Andrzejewski"}
            };
          
        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }
    }
}