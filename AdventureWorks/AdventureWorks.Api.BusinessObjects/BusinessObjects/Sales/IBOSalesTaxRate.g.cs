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
		Task<CreateResponse<int>> Create(
			SalesTaxRateModel model);

		Task<ActionResponse> Update(int salesTaxRateID,
		                            SalesTaxRateModel model);

		Task<ActionResponse> Delete(int salesTaxRateID);

		ApiResponse GetById(int salesTaxRateID);

		POCOSalesTaxRate GetByIdDirect(int salesTaxRateID);

		ApiResponse GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesTaxRate> GetWhereDirect(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8a00c2d70d96e5d8e7dbf01b718e20d4</Hash>
</Codenesium>*/