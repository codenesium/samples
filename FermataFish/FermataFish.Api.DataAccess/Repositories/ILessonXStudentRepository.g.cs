using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ILessonXStudentRepository
        {
                Task<LessonXStudent> Create(LessonXStudent item);

                Task Update(LessonXStudent item);

                Task Delete(int id);

                Task<LessonXStudent> Get(int id);

                Task<List<LessonXStudent>> All(int limit = int.MaxValue, int offset = 0);

                Task<Lesson> GetLesson(int lessonId);
                Task<Student> GetStudent(int studentId);
        }
}

/*<Codenesium>
    <Hash>b6d730d621bccb76cdce0e7a77fde2d4</Hash>
</Codenesium>*/