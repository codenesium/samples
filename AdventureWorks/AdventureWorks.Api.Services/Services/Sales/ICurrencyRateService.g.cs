using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICurrencyRateService
	{
		Task<CreateResponse<ApiCurrencyRateServerResponseModel>> Create(
			ApiCurrencyRateServerRequestModel model);

		Task<UpdateResponse<ApiCurrencyRateServerResponseModel>> Update(int currencyRateID,
		                                                                 ApiCurrencyRateServerRequestModel model);

		Task<ActionResponse> Delete(int currencyRateID);

		Task<ApiCurrencyRateServerResponseModel> Get(int currencyRateID);

		Task<List<ApiCurrencyRateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCurrencyRateServerResponseModel> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3652ce6b6f7dd6622ed1cf8bf9676016</Hash>
</Codenesium>*/