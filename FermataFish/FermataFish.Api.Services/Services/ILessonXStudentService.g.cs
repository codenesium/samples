using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface ILessonXStudentService
	{
		Task<CreateResponse<ApiLessonXStudentResponseModel>> Create(
			ApiLessonXStudentRequestModel model);

		Task<UpdateResponse<ApiLessonXStudentResponseModel>> Update(int id,
		                                                             ApiLessonXStudentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonXStudentResponseModel> Get(int id);

		Task<List<ApiLessonXStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLessonXStudentResponseModel>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8cf6263b2da7c8974b0006220d900198</Hash>
</Codenesium>*/