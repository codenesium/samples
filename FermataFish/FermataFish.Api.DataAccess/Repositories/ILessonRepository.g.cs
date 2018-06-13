using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ILessonRepository
        {
                Task<Lesson> Create(Lesson item);

                Task Update(Lesson item);

                Task Delete(int id);

                Task<Lesson> Get(int id);

                Task<List<Lesson>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<LessonXStudent>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0);
                Task<List<LessonXTeacher>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>3abe8fa766919f2d3496092257868a17</Hash>
</Codenesium>*/