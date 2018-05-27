using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLesson
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
    <Hash>82a4710d39a2170b15d63bb1887feed7</Hash>
</Codenesium>*/