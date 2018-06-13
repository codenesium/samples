using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiCountryRegionCurrencyResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiCountryRegionCurrencyResponseModel>> GetCurrencyCode(string currencyCode);
        }
}

/*<Codenesium>
    <Hash>92cf7f84a48862acbe0b6e7fd7862abf</Hash>
</Codenesium>*/