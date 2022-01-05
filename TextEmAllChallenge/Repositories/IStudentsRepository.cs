using System.Collections.Generic;
using System.Threading.Tasks;
using TextEmAllChallenge.Models;

namespace TextEmAllChallenge.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetStudents();
    }
}