using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface ILessonXTeacherService
	{
		Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
			ApiLessonXTeacherRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLessonXTeacherRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonXTeacherResponseModel> Get(int id);

		Task<List<ApiLessonXTeacherResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>41c7d4b20b20eba5a1bd3a4fd6642654</Hash>
</Codenesium>*/