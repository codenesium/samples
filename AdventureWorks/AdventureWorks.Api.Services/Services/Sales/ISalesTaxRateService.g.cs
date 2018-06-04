using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesTaxRateService
	{
		Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
			ApiSalesTaxRateRequestModel model);

		Task<ActionResponse> Update(int salesTaxRateID,
		                            ApiSalesTaxRateRequestModel model);

		Task<ActionResponse> Delete(int salesTaxRateID);

		Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID);

		Task<List<ApiSalesTaxRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiSalesTaxRateResponseModel> GetStateProvinceIDTaxType(int stateProvinceID,int taxType);
	}
}

/*<Codenesium>
    <Hash>8697d88d8af5f3ccce0dfcd750b73800</Hash>
</Codenesium>*/