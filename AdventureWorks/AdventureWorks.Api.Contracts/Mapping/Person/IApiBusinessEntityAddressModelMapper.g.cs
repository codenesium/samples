using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBusinessEntityAddressModelMapper
        {
                ApiBusinessEntityAddressResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityAddressRequestModel request);

                ApiBusinessEntityAddressRequestModel MapResponseToRequest(
                        ApiBusinessEntityAddressResponseModel response);

                JsonPatchDocument<ApiBusinessEntityAddressRequestModel> CreatePatch(ApiBusinessEntityAddressRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c1027e55ecf2d0a4519d6a7498cfcd4b</Hash>
</Codenesium>*/