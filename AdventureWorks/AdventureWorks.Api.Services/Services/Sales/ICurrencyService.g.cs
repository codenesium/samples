using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ICurrencyService
        {
                Task<CreateResponse<ApiCurrencyResponseModel>> Create(
                        ApiCurrencyRequestModel model);

                Task<ActionResponse> Update(string currencyCode,
                                            ApiCurrencyRequestModel model);

                Task<ActionResponse> Delete(string currencyCode);

                Task<ApiCurrencyResponseModel> Get(string currencyCode);

                Task<List<ApiCurrencyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCurrencyResponseModel> ByName(string name);

                Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiCurrencyRateResponseModel>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5f672c81f1ce15136301db9c6f858183</Hash>
</Codenesium>*/