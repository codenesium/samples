using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IPaymentTypeService
	{
		Task<CreateResponse<ApiPaymentTypeServerResponseModel>> Create(
			ApiPaymentTypeServerRequestModel model);

		Task<UpdateResponse<ApiPaymentTypeServerResponseModel>> Update(int id,
		                                                                ApiPaymentTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPaymentTypeServerResponseModel> Get(int id);

		Task<List<ApiPaymentTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleServerResponseModel>> SalesByPaymentTypeId(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9035ae1e23c6d241feb08c17666088be</Hash>
</Codenesium>*/