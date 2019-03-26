using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICurrencyService
	{
		Task<CreateResponse<ApiCurrencyServerResponseModel>> Create(
			ApiCurrencyServerRequestModel model);

		Task<UpdateResponse<ApiCurrencyServerResponseModel>> Update(string currencyCode,
		                                                             ApiCurrencyServerRequestModel model);

		Task<ActionResponse> Delete(string currencyCode);

		Task<ApiCurrencyServerResponseModel> Get(string currencyCode);

		Task<List<ApiCurrencyServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiCurrencyServerResponseModel> ByName(string name);

		Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCurrencyRateServerResponseModel>> CurrencyRatesByToCurrencyCode(string toCurrencyCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>83bf16bb8fe4564d5728165e6eec384c</Hash>
</Codenesium>*/