using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonStatusRepository
	{
		Task<POCOLessonStatus> Create(ApiLessonStatusModel model);

		Task Update(int id,
		            ApiLessonStatusModel model);

		Task Delete(int id);

		Task<POCOLessonStatus> Get(int id);

		Task<List<POCOLessonStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f00e743ff01ffa2ea6679f9b64862c9f</Hash>
</Codenesium>*/