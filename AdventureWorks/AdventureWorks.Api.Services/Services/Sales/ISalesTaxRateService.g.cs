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

		Task<List<ApiSalesTaxRateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiSalesTaxRateServerResponseModel> ByRowguid(Guid rowguid);

		Task<ApiSalesTaxRateServerResponseModel> ByStateProvinceIDTaxType(int stateProvinceID, int taxType);
	}
}

/*<Codenesium>
    <Hash>7d00bd0882184d18a04cdef2b25dd20d</Hash>
</Codenesium>*/