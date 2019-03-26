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

		Task<List<ApiSalesReasonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>e6f8cc193cf5ccd7b3013be7fe6c696b</Hash>
</Codenesium>*/