using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IStudentRepository
        {
                Task<Student> Create(Student item);

                Task Update(Student item);

                Task Delete(int id);

                Task<Student> Get(int id);

                Task<List<Student>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<LessonXStudent>> LessonXStudents(int studentId, int limit = int.MaxValue, int offset = 0);
                Task<List<LessonXTeacher>> LessonXTeachers(int studentId, int limit = int.MaxValue, int offset = 0);
                Task<List<StudentXFamily>> StudentXFamilies(int studentId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>452d7984038bc3339b7a61c574ece0e1</Hash>
</Codenesium>*/