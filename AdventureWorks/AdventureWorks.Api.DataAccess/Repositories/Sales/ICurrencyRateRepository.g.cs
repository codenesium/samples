using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRateRepository
	{
		Task<DTOCurrencyRate> Create(DTOCurrencyRate dto);

		Task Update(int currencyRateID,
		            DTOCurrencyRate dto);

		Task Delete(int currencyRateID);

		Task<DTOCurrencyRate> Get(int currencyRateID);

		Task<List<DTOCurrencyRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOCurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>ebcfbc62c3874478df0fdfa99747fe90</Hash>
</Codenesium>*/