using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRateRepository
	{
		Task<POCOCurrencyRate> Create(ApiCurrencyRateModel model);

		Task Update(int currencyRateID,
		            ApiCurrencyRateModel model);

		Task Delete(int currencyRateID);

		Task<POCOCurrencyRate> Get(int currencyRateID);

		Task<List<POCOCurrencyRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>f9d34496170c3726ff77950e120dff88</Hash>
</Codenesium>*/