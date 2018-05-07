using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCurrencyRate
	{
		Task<CreateResponse<int>> Create(
			CurrencyRateModel model);

		Task<ActionResponse> Update(int currencyRateID,
		                            CurrencyRateModel model);

		Task<ActionResponse> Delete(int currencyRateID);

		POCOCurrencyRate Get(int currencyRateID);

		List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>27ab7d8a16293a8629b1fa04fdb58276</Hash>
</Codenesium>*/