using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>8425bd8e86ffb4801d06b74a04f7b0c3</Hash>
</Codenesium>*/