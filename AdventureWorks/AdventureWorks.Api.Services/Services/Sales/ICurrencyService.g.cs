using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiCurrencyResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiCurrencyResponseModel> GetName(string name);

                Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiCurrencyRateResponseModel>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f942ca407892dc78bd1ac5c37329cf74</Hash>
</Codenesium>*/