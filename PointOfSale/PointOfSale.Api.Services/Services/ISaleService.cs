using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface ISaleService
	{
		Task<CreateResponse<ApiSaleServerResponseModel>> Create(
			ApiSaleServerRequestModel model);

		Task<UpdateResponse<ApiSaleServerResponseModel>> Update(int id,
		                                                         ApiSaleServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleServerResponseModel> Get(int id);

		Task<List<ApiSaleServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiSaleServerResponseModel>> ByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e28570d020b2b0a206e0393022d59cbd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/