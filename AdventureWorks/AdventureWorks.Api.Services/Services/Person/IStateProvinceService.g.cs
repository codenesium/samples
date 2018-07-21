using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IStateProvinceService
        {
                Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
                        ApiStateProvinceRequestModel model);

                Task<UpdateResponse<ApiStateProvinceResponseModel>> Update(int stateProvinceID,
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
    <Hash>1acbf765b1b9396c6976bdde6ea8c180</Hash>
</Codenesium>*/