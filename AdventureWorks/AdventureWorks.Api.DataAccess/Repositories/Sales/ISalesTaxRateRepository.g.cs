using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesTaxRateRepository
	{
		Task<SalesTaxRate> Create(SalesTaxRate item);

		Task Update(SalesTaxRate item);

		Task Delete(int salesTaxRateID);

		Task<SalesTaxRate> Get(int salesTaxRateID);

		Task<List<SalesTaxRate>> All(int limit = int.MaxValue, int offset = 0);

		Task<SalesTaxRate> ByRowguid(Guid rowguid);

		Task<SalesTaxRate> ByStateProvinceIDTaxType(int stateProvinceID, int taxType);
	}
}

/*<Codenesium>
    <Hash>aca998fd7d86dcce979f0681ebf8da5a</Hash>
</Codenesium>*/