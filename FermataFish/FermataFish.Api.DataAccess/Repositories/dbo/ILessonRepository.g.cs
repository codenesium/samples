using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		Task<POCOLesson> Create(ApiLessonModel model);

		Task Update(int id,
		            ApiLessonModel model);

		Task Delete(int id);

		Task<POCOLesson> Get(int id);

		Task<List<POCOLesson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c6a4006fe8a00af0103a75bfa4f82307</Hash>
</Codenesium>*/