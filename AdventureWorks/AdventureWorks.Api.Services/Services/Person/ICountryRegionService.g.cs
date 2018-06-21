using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ICountryRegionService
        {
                Task<CreateResponse<ApiCountryRegionResponseModel>> Create(
                        ApiCountryRegionRequestModel model);

                Task<ActionResponse> Update(string countryRegionCode,
                                            ApiCountryRegionRequestModel model);

                Task<ActionResponse> Delete(string countryRegionCode);

                Task<ApiCountryRegionResponseModel> Get(string countryRegionCode);

                Task<List<ApiCountryRegionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCountryRegionResponseModel> ByName(string name);

                Task<List<ApiStateProvinceResponseModel>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>197b892260777a3a1a72e923652a3098</Hash>
</Codenesium>*/