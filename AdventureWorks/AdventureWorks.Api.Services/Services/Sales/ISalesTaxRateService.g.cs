using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesTaxRateService
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
    <Hash>dd221a1df550786c8da30712f34bf312</Hash>
</Codenesium>*/