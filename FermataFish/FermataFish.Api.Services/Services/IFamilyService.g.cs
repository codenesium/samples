using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface IFamilyService
	{
		Task<CreateResponse<ApiFamilyResponseModel>> Create(
			ApiFamilyRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFamilyRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFamilyResponseModel> Get(int id);

		Task<List<ApiFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>afeabbef41c34ea5f109e16442d99c0f</Hash>
</Codenesium>*/