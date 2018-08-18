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
	}
}

/*<Codenesium>
    <Hash>0d5def600fbfd4b0edae76ec803baf93</Hash>
</Codenesium>*/