using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpace
	{
		Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceResponseModel> Get(int id);

		Task<List<ApiSpaceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3e03411efa9832943f35ee72ce1af548</Hash>
</Codenesium>*/