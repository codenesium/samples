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

                Task<UpdateResponse<ApiCountryRegionResponseModel>> Update(string countryRegionCode,
                                                                            ApiCountryRegionRequestModel model);

                Task<ActionResponse> Delete(string countryRegionCode);

                Task<ApiCountryRegionResponseModel> Get(string countryRegionCode);

                Task<List<ApiCountryRegionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCountryRegionResponseModel> ByName(string name);

                Task<List<ApiStateProvinceResponseModel>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6d6694dc1dd8679d3ef703cceffdebce</Hash>
</Codenesium>*/