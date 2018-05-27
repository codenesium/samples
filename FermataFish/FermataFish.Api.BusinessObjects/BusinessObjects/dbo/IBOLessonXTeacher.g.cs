using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonXTeacher
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
    <Hash>45d30a98db35766a7de6bd58ad23557b</Hash>
</Codenesium>*/