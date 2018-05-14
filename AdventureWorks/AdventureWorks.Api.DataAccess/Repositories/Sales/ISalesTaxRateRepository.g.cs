using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTaxRateRepository
	{
		POCOSalesTaxRate Create(ApiSalesTaxRateModel model);

		void Update(int salesTaxRateID,
		            ApiSalesTaxRateModel model);

		void Delete(int salesTaxRateID);

		POCOSalesTaxRate Get(int salesTaxRateID);

		List<POCOSalesTaxRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOSalesTaxRate GetStateProvinceIDTaxType(int stateProvinceID,int taxType);
	}
}

/*<Codenesium>
    <Hash>74983ffa2c421afd1fc9ab38b96d9572</Hash>
</Codenesium>*/