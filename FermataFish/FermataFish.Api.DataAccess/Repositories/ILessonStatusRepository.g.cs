using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonStatusRepository
	{
		Task<LessonStatus> Create(LessonStatus item);

		Task Update(LessonStatus item);

		Task Delete(int id);

		Task<LessonStatus> Get(int id);

		Task<List<LessonStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3a423d3e38ad5c418b29b05addee013e</Hash>
</Codenesium>*/