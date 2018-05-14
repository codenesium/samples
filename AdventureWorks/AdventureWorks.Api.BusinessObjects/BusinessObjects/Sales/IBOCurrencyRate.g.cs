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
		Task<CreateResponse<POCOCurrencyRate>> Create(
			ApiCurrencyRateModel model);

		Task<ActionResponse> Update(int currencyRateID,
		                            ApiCurrencyRateModel model);

		Task<ActionResponse> Delete(int currencyRateID);

		POCOCurrencyRate Get(int currencyRateID);

		List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCurrencyRate GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>ab67bbb891d01d67c4e00df5d5b6636f</Hash>
</Codenesium>*/