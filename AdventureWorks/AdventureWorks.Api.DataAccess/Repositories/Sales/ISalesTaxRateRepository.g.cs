using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTaxRateRepository
	{
		Task<DTOSalesTaxRate> Create(DTOSalesTaxRate dto);

		Task Update(int salesTaxRateID,
		            DTOSalesTaxRate dto);

		Task Delete(int salesTaxRateID);

		Task<DTOSalesTaxRate> Get(int salesTaxRateID);

		Task<List<DTOSalesTaxRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOSalesTaxRate> GetStateProvinceIDTaxType(int stateProvinceID,int taxType);
	}
}

/*<Codenesium>
    <Hash>3ec32896a3b9bb12acf14f7a0e2aa8b0</Hash>
</Codenesium>*/