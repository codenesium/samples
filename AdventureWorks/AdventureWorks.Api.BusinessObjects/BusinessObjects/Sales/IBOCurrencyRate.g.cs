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
		Task<CreateResponse<ApiCurrencyRateResponseModel>> Create(
			ApiCurrencyRateRequestModel model);

		Task<ActionResponse> Update(int currencyRateID,
		                            ApiCurrencyRateRequestModel model);

		Task<ActionResponse> Delete(int currencyRateID);

		Task<ApiCurrencyRateResponseModel> Get(int currencyRateID);

		Task<List<ApiCurrencyRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiCurrencyRateResponseModel> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode);
	}
}

/*<Codenesium>
    <Hash>c62e402545867088e3de1b5c6ead7ad3</Hash>
</Codenesium>*/