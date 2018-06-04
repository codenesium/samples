using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface ILessonXStudentService
	{
		Task<CreateResponse<ApiLessonXStudentResponseModel>> Create(
			ApiLessonXStudentRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonXStudentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonXStudentResponseModel> Get(int id);

		Task<List<ApiLessonXStudentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>17a8599f9835202795b5e5296d468925</Hash>
</Codenesium>*/