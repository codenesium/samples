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

		POCOSalesTaxRate Get(int salesTaxRateID);

		List<POCOSalesTaxRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a23e1039c5c693fd1f231a850febb21c</Hash>
</Codenesium>*/