using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudent
	{
		Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudentResponseModel> Get(int id);

		Task<List<ApiStudentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7892fe7c8c775b7a1a78eda87fd0b548</Hash>
</Codenesium>*/