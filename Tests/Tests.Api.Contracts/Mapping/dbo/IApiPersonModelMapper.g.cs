using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiPersonModelMapper
        {
                ApiPersonResponseModel MapRequestToResponse(
                        int personId,
                        ApiPersonRequestModel request);

                ApiPersonRequestModel MapResponseToRequest(
                        ApiPersonResponseModel response);

                JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7227955aa250f6ac40a35dffc9e9b8aa</Hash>
</Codenesium>*/