using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTaxRateRepository
	{
		int Create(SalesTaxRateModel model);

		void Update(int salesTaxRateID,
		            SalesTaxRateModel model);

		void Delete(int salesTaxRateID);

		POCOSalesTaxRate Get(int salesTaxRateID);

		List<POCOSalesTaxRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9b36e92a91b5e80cc70f150eacd962b3</Hash>
</Codenesium>*/