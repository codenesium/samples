using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonXStudent
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
    <Hash>1a6b8af3a766044781338e4ac34d5134</Hash>
</Codenesium>*/