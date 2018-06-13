using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiCountryRegionResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiCountryRegionResponseModel> GetName(string name);

                Task<List<ApiStateProvinceResponseModel>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>383ca571be34754fb0a86306ae9f8b45</Hash>
</Codenesium>*/