using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ICountryRegionCurrencyService
        {
                Task<CreateResponse<ApiCountryRegionCurrencyResponseModel>> Create(
                        ApiCountryRegionCurrencyRequestModel model);

                Task<ActionResponse> Update(string countryRegionCode,
                                            ApiCountryRegionCurrencyRequestModel model);

                Task<ActionResponse> Delete(string countryRegionCode);

                Task<ApiCountryRegionCurrencyResponseModel> Get(string countryRegionCode);

                Task<List<ApiCountryRegionCurrencyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiCountryRegionCurrencyResponseModel>> ByCurrencyCode(string currencyCode);
        }
}

/*<Codenesium>
    <Hash>886f8fe62aab63d107b9aba5f40f6e49</Hash>
</Codenesium>*/