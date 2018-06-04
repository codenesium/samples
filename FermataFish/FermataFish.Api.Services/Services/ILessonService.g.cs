using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface ILessonService
	{
		Task<CreateResponse<ApiLessonResponseModel>> Create(
			ApiLessonRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonResponseModel> Get(int id);

		Task<List<ApiLessonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9b2a33917c484667e8201376ab862ce6</Hash>
</Codenesium>*/