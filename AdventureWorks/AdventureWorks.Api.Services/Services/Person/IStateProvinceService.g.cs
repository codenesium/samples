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

                Task<List<ApiStateProvinceResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiStateProvinceResponseModel> GetName(string name);
                Task<ApiStateProvinceResponseModel> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

                Task<List<ApiAddressResponseModel>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fd177da469330e4a619659c06f7d9475</Hash>
</Codenesium>*/