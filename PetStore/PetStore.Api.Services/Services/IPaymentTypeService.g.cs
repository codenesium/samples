using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IPaymentTypeService
	{
		Task<CreateResponse<ApiPaymentTypeResponseModel>> Create(
			ApiPaymentTypeRequestModel model);

		Task<UpdateResponse<ApiPaymentTypeResponseModel>> Update(int id,
		                                                          ApiPaymentTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPaymentTypeResponseModel> Get(int id);

		Task<List<ApiPaymentTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleResponseModel>> SalesByPaymentTypeId(int paymentTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3432848d37f88bcf9de143c59090e9a0</Hash>
</Codenesium>*/