using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface ILessonStatusService
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
    <Hash>1636738c8ae9ff6b06d416d7f1bd233f</Hash>
</Codenesium>*/