using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesTaxRate
	{
		Task<CreateResponse<POCOSalesTaxRate>> Create(
			ApiSalesTaxRateModel model);

		Task<ActionResponse> Update(int salesTaxRateID,
		                            ApiSalesTaxRateModel model);

		Task<ActionResponse> Delete(int salesTaxRateID);

		Task<POCOSalesTaxRate> Get(int salesTaxRateID);

		Task<List<POCOSalesTaxRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOSalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID,int taxType);
	}
}

/*<Codenesium>
    <Hash>3768de128026bbb1e5fa6a75aead6e29</Hash>
</Codenesium>*/