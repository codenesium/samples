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

		Task<List<SalesOrderHeader>> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int limit = int.MaxValue, int offset = 0);

		Task<Currency> CurrencyByFromCurrencyCode(string fromCurrencyCode);

		Task<Currency> CurrencyByToCurrencyCode(string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>f1ba3eb6c30b520dae3188a684ea3209</Hash>
</Codenesium>*/