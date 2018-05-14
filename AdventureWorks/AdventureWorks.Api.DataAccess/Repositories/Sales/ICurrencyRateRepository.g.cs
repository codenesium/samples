using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRateRepository
	{
		POCOCurrencyRate Create(ApiCurrencyRateModel model);

		void Update(int currencyRateID,
		            ApiCurrencyRateModel model);

		void Delete(int currencyRateID);

		POCOCurrencyRate Get(int currencyRateID);

		List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCurrencyRate GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>2a4dd6a202cbe2f2046a6d0bffac3252</Hash>
</Codenesium>*/