using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ILessonXTeacherRepository
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
    <Hash>c6746c2b91ea69813f420b0f74204cd7</Hash>
</Codenesium>*/