using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPasswordService
	{
		Task<CreateResponse<ApiPasswordResponseModel>> Create(
			ApiPasswordRequestModel model);

		Task<UpdateResponse<ApiPasswordResponseModel>> Update(int businessEntityID,
		                                                       ApiPasswordRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPasswordResponseModel> Get(int businessEntityID);

		Task<List<ApiPasswordResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e0f20f694a183ac3d69c6a3deabad0e9</Hash>
</Codenesium>*/