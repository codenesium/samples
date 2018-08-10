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

		Task<SalesTaxRate> ByStateProvinceIDTaxType(int stateProvinceID, int taxType);
	}
}

/*<Codenesium>
    <Hash>8270224016bba15e7f52c6fca422867f</Hash>
</Codenesium>*/