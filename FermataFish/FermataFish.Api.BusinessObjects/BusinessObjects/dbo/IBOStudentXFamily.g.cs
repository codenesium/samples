using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudentXFamily
	{
		Task<CreateResponse<ApiStudentXFamilyResponseModel>> Create(
			ApiStudentXFamilyRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudentXFamilyRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudentXFamilyResponseModel> Get(int id);

		Task<List<ApiStudentXFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>adfa3f15096b947ed1d68ece52625891</Hash>
</Codenesium>*/