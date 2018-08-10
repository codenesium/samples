using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ILessonStatusRepository
	{
		Task<LessonStatus> Create(LessonStatus item);

		Task Update(LessonStatus item);

		Task Delete(int id);

		Task<LessonStatus> Get(int id);

		Task<List<LessonStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Lesson>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0);

		Task<Studio> GetStudio(int id);
	}
}

/*<Codenesium>
    <Hash>7ea0bf2974c96c21284d23c43d091e63</Hash>
</Codenesium>*/