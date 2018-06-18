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

                Task<List<ApiStateProvinceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiStateProvinceResponseModel> ByName(string name);
                Task<ApiStateProvinceResponseModel> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

                Task<List<ApiAddressResponseModel>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1a3aca8e65335b624e76caf309f58bb1</Hash>
</Codenesium>*/