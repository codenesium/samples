using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOFamily
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
    <Hash>1d680ed33de86c40dadd9270b97cbad8</Hash>
</Codenesium>*/