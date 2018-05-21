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

		Task<POCOCurrencyRate> Get(int currencyRateID);

		Task<List<POCOCurrencyRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>31ace1cc26da2c862bdfe054a7b953d8</Hash>
</Codenesium>*/