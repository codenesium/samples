using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTaxRateRepository
	{
		Task<POCOSalesTaxRate> Create(ApiSalesTaxRateModel model);

		Task Update(int salesTaxRateID,
		            ApiSalesTaxRateModel model);

		Task Delete(int salesTaxRateID);

		Task<POCOSalesTaxRate> Get(int salesTaxRateID);

		Task<List<POCOSalesTaxRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOSalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID,int taxType);
	}
}

/*<Codenesium>
    <Hash>266520deb1e0c5a3fedf397998774c7e</Hash>
</Codenesium>*/