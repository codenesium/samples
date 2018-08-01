using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public interface IPaymentTypeService
	{
		Task<CreateResponse<ApiPaymentTypeResponseModel>> Create(
			ApiPaymentTypeRequestModel model);

		Task<UpdateResponse<ApiPaymentTypeResponseModel>> Update(int id,
		                                                          ApiPaymentTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPaymentTypeResponseModel> Get(int id);

		Task<List<ApiPaymentTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleResponseModel>> Sales(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>13ee0b1e9fb32a76019147933047d67e</Hash>
</Codenesium>*/