using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiStateProvinceModelMapper
        {
                ApiStateProvinceResponseModel MapRequestToResponse(
                        int stateProvinceID,
                        ApiStateProvinceRequestModel request);

                ApiStateProvinceRequestModel MapResponseToRequest(
                        ApiStateProvinceResponseModel response);

                JsonPatchDocument<ApiStateProvinceRequestModel> CreatePatch(ApiStateProvinceRequestModel model);
        }
}

/*<Codenesium>
    <Hash>fb481e78242807ca2a0e29f85c746233</Hash>
</Codenesium>*/