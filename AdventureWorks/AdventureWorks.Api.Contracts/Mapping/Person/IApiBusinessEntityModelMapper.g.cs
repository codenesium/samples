using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBusinessEntityModelMapper
        {
                ApiBusinessEntityResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityRequestModel request);

                ApiBusinessEntityRequestModel MapResponseToRequest(
                        ApiBusinessEntityResponseModel response);

                JsonPatchDocument<ApiBusinessEntityRequestModel> CreatePatch(ApiBusinessEntityRequestModel model);
        }
}

/*<Codenesium>
    <Hash>9715a4dd2e556c0dc7eff8365d4c3c99</Hash>
</Codenesium>*/