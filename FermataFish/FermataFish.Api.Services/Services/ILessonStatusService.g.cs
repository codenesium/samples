using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface ILessonStatusService
	{
		Task<CreateResponse<ApiLessonStatusResponseModel>> Create(
			ApiLessonStatusRequestModel model);

		Task<UpdateResponse<ApiLessonStatusResponseModel>> Update(int id,
		                                                           ApiLessonStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonStatusResponseModel> Get(int id);

		Task<List<ApiLessonStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLessonResponseModel>> Lessons(int lessonStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>eac58b41b75f9ae224fe25004dd0fc22</Hash>
</Codenesium>*/