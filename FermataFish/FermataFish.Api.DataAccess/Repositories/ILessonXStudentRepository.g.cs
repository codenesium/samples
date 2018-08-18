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

		Task<Lesson> GetLesson(int lessonId);

		Task<Student> GetStudent(int studentId);
	}
}

/*<Codenesium>
    <Hash>42c990311880b9b964817711e736cd34</Hash>
</Codenesium>*/