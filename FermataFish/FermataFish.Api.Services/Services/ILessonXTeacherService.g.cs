using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface ILessonXTeacherService
	{
		Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
			ApiLessonXTeacherRequestModel model);

		Task<UpdateResponse<ApiLessonXTeacherResponseModel>> Update(int id,
		                                                             ApiLessonXTeacherRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonXTeacherResponseModel> Get(int id);

		Task<List<ApiLessonXTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0cf3769679b58f91d6b2a968e4cbd0ac</Hash>
</Codenesium>*/