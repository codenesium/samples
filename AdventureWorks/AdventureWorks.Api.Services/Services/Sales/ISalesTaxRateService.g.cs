using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesTaxRateService
	{
		Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
			ApiSalesTaxRateRequestModel model);

		Task<UpdateResponse<ApiSalesTaxRateResponseModel>> Update(int salesTaxRateID,
		                                                           ApiSalesTaxRateRequestModel model);

		Task<ActionResponse> Delete(int salesTaxRateID);

		Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID);

		Task<List<ApiSalesTaxRateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSalesTaxRateResponseModel> ByStateProvinceIDTaxType(int stateProvinceID, int taxType);
	}
}

/*<Codenesium>
    <Hash>4f4ad0479502e81819509fb2889b8cff</Hash>
</Codenesium>*/