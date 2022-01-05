using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextEmAllChallenge.Context;
using TextEmAllChallenge.Models;

namespace TextEmAllChallenge.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly SchoolContext _schoolContext;

        public StudentsRepository(SchoolContext schoolContext)
        {            
            _schoolContext = schoolContext;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {          
            // look up all the student grades from the db, including the student property
            var studentGrades = await _schoolContext.StudentGrades.Include(sg => sg.Student).ToListAsync();

            // return all the students, with their calculated GPAs
            return studentGrades
                .GroupBy(studentGrade => studentGrade.StudentId) // multiple rows per student, so group by student id
                .Select(studentGrouping => new Student()
                {
                    StudentId = studentGrouping.Key,
                    FirstName = studentGrouping.First().Student?.FirstName, // get the first name from the first row in the grouping
                    LastName = studentGrouping.First().Student?.LastName, // get the last name from the first row in the grouping
                    GPA = studentGrouping.Select(sg => sg.Grade).Average() // calculate the average GPAs (the Average() method handles nulls)
                });
        }
    }
}
