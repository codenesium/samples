using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ILessonXTeacherRepository
        {
                Task<LessonXTeacher> Create(LessonXTeacher item);

                Task Update(LessonXTeacher item);

                Task Delete(int id);

                Task<LessonXTeacher> Get(int id);

                Task<List<LessonXTeacher>> All(int limit = int.MaxValue, int offset = 0);

                Task<Lesson> GetLesson(int lessonId);
                Task<Student> GetStudent(int studentId);
        }
}

/*<Codenesium>
    <Hash>0ff989b1e203e041c7f6c503707975b0</Hash>
</Codenesium>*/