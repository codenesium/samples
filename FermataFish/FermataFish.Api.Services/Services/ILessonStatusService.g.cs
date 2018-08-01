using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface ILessonStatusService
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
    <Hash>6b2e0237a6559c70f9921a45ff0c14de</Hash>
</Codenesium>*/