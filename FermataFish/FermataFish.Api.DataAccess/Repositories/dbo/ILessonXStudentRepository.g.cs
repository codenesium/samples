using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXStudentRepository
	{
		Task<POCOLessonXStudent> Create(ApiLessonXStudentModel model);

		Task Update(int id,
		            ApiLessonXStudentModel model);

		Task Delete(int id);

		Task<POCOLessonXStudent> Get(int id);

		Task<List<POCOLessonXStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>61c8ccab798ac1ec8b8a900be21cab0b</Hash>
</Codenesium>*/