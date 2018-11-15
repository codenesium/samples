using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesReasonService
	{
		Task<CreateResponse<ApiSalesReasonServerResponseModel>> Create(
			ApiSalesReasonServerRequestModel model);

		Task<UpdateResponse<ApiSalesReasonServerResponseModel>> Update(int salesReasonID,
		                                                                ApiSalesReasonServerRequestModel model);

		Task<ActionResponse> Delete(int salesReasonID);

		Task<ApiSalesReasonServerResponseModel> Get(int salesReasonID);

		Task<List<ApiSalesReasonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f64f5a0f337798a3b363032aa2596ead</Hash>
</Codenesium>*/