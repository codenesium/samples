using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesTaxRateService
	{
		Task<CreateResponse<ApiSalesTaxRateServerResponseModel>> Create(
			ApiSalesTaxRateServerRequestModel model);

		Task<UpdateResponse<ApiSalesTaxRateServerResponseModel>> Update(int salesTaxRateID,
		                                                                 ApiSalesTaxRateServerRequestModel model);

		Task<ActionResponse> Delete(int salesTaxRateID);

		Task<ApiSalesTaxRateServerResponseModel> Get(int salesTaxRateID);

		Task<List<ApiSalesTaxRateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSalesTaxRateServerResponseModel> ByRowguid(Guid rowguid);

		Task<ApiSalesTaxRateServerResponseModel> ByStateProvinceIDTaxType(int stateProvinceID, int taxType);
	}
}

/*<Codenesium>
    <Hash>552416237c55b3f320d1dbf0cf41933e</Hash>
</Codenesium>*/