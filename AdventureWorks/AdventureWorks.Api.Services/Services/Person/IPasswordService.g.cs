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
    <Hash>1ced808e355084b0806a0c4983f9e414</Hash>
</Codenesium>*/