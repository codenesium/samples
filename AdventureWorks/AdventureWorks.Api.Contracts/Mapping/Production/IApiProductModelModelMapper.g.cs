using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelModelMapper
        {
                ApiProductModelResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelRequestModel request);

                ApiProductModelRequestModel MapResponseToRequest(
                        ApiProductModelResponseModel response);

                JsonPatchDocument<ApiProductModelRequestModel> CreatePatch(ApiProductModelRequestModel model);
        }
}

/*<Codenesium>
    <Hash>dc4ff46926ab2e4b9f8405cc19321211</Hash>
</Codenesium>*/