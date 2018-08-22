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

		Task<List<LessonStatus>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<Studio> GetStudio(int id);
	}
}

/*<Codenesium>
    <Hash>e495a8a969e42086eaedbb9cbc647c3b</Hash>
</Codenesium>*/