using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface ISaleService
	{
		Task<CreateResponse<ApiSaleServerResponseModel>> Create(
			ApiSaleServerRequestModel model);

		Task<UpdateResponse<ApiSaleServerResponseModel>> Update(int id,
		                                                         ApiSaleServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleServerResponseModel> Get(int id);

		Task<List<ApiSaleServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>adb1a0cf9809fec6e4c4cdd645ca8744</Hash>
</Codenesium>*/