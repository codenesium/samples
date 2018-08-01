using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		Task<Lesson> Create(Lesson item);

		Task Update(Lesson item);

		Task Delete(int id);

		Task<Lesson> Get(int id);

		Task<List<Lesson>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<LessonXStudent>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0);

		Task<List<LessonXTeacher>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0);

		Task<LessonStatus> GetLessonStatus(int lessonStatusId);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>3d5be8e9b2282f388195bc77a6aa6360</Hash>
</Codenesium>*/