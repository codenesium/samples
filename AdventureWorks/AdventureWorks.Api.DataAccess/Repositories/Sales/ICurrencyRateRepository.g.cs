using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICurrencyRateRepository
	{
		Task<CurrencyRate> Create(CurrencyRate item);

		Task Update(CurrencyRate item);

		Task Delete(int currencyRateID);

		Task<CurrencyRate> Get(int currencyRateID);

		Task<List<CurrencyRate>> All(int limit = int.MaxValue, int offset = 0);

		Task<CurrencyRate> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

		Task<List<SalesOrderHeader>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0);

		Task<Currency> CurrencyByFromCurrencyCode(string fromCurrencyCode);

		Task<Currency> CurrencyByToCurrencyCode(string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>022af2a010a7bdb572c13589064597a2</Hash>
</Codenesium>*/