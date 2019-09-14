using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
	}
}

/*<Codenesium>
    <Hash>3d71c879528a97066825b8de151361f6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/