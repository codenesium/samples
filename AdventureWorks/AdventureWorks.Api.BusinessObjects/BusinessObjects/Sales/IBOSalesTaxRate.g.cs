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
		Task<CreateResponse<POCOSalesTaxRate>> Create(
			ApiSalesTaxRateModel model);

		Task<ActionResponse> Update(int salesTaxRateID,
		                            ApiSalesTaxRateModel model);

		Task<ActionResponse> Delete(int salesTaxRateID);

		POCOSalesTaxRate Get(int salesTaxRateID);

		List<POCOSalesTaxRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOSalesTaxRate GetStateProvinceIDTaxType(int stateProvinceID,int taxType);
	}
}

/*<Codenesium>
    <Hash>6050291b99fd809c741ffe658afe056f</Hash>
</Codenesium>*/