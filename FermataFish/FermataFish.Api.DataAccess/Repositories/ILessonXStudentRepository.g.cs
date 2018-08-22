using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ILessonXStudentRepository
	{
		Task<LessonXStudent> Create(LessonXStudent item);

		Task Update(LessonXStudent item);

		Task Delete(int id);

		Task<LessonXStudent> Get(int id);

		Task<List<LessonXStudent>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<LessonXStudent>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<Lesson> GetLesson(int lessonId);

		Task<Student> GetStudent(int studentId);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>6c412323cc8e83c5b78b83a50b81da90</Hash>
</Codenesium>*/