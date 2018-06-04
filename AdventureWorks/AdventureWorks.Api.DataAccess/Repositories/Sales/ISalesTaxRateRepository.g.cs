using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTaxRateRepository
	{
		Task<SalesTaxRate> Create(SalesTaxRate item);

		Task Update(SalesTaxRate item);

		Task Delete(int salesTaxRateID);

		Task<SalesTaxRate> Get(int salesTaxRateID);

		Task<List<SalesTaxRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<SalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID,int taxType);
	}
}

/*<Codenesium>
    <Hash>a0fec75c48623fd9c3c83f321e73274e</Hash>
</Codenesium>*/