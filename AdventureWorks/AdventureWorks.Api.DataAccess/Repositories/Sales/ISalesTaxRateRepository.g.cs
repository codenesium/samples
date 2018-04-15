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

		ApiResponse GetById(int salesTaxRateID);

		POCOSalesTaxRate GetByIdDirect(int salesTaxRateID);

		ApiResponse GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTaxRate> GetWhereDirect(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b6bd8f17cb06839c2f92541b30c358d8</Hash>
</Codenesium>*/