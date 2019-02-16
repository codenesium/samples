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

		Task<List<ApiPaymentTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiSaleServerResponseModel>> SalesByPaymentTypeId(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e780c93c4c589a97a9488ee6fd7ba9d2</Hash>
</Codenesium>*/