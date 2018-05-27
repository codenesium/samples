using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonStatus
	{
		Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
			ApiLessonStatusRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonStatusResponseModel> Get(int id);

		Task<List<ApiLessonStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7a1c5a67364c23ce4c4aa740f23e39c0</Hash>
</Codenesium>*/