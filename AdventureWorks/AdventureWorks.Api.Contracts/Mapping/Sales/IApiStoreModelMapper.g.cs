using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiStoreModelMapper
        {
                ApiStoreResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiStoreRequestModel request);

                ApiStoreRequestModel MapResponseToRequest(
                        ApiStoreResponseModel response);

                JsonPatchDocument<ApiStoreRequestModel> CreatePatch(ApiStoreRequestModel model);
        }
}

/*<Codenesium>
    <Hash>3d7e8b0b6ee4e9d3893186cb33c56914</Hash>
</Codenesium>*/