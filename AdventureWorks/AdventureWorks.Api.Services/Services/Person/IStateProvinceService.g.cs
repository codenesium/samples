using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IStateProvinceService
        {
                Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
                        ApiStateProvinceRequestModel model);

                Task<ActionResponse> Update(int stateProvinceID,
                                            ApiStateProvinceRequestModel model);

                Task<ActionResponse> Delete(int stateProvinceID);

                Task<ApiStateProvinceResponseModel> Get(int stateProvinceID);

                Task<List<ApiStateProvinceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiStateProvinceResponseModel> GetName(string name);
                Task<ApiStateProvinceResponseModel> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);
        }
}

/*<Codenesium>
    <Hash>dc9d36d8a53b43c990364bc49374c9d1</Hash>
</Codenesium>*/