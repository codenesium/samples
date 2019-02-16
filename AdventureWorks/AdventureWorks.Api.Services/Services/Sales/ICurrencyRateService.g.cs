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

		Task<List<ApiCurrencyRateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiCurrencyRateServerResponseModel> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>23c49e28acc816d4a6a086d458ee71c9</Hash>
</Codenesium>*/