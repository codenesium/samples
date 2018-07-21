using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPersonModelMapper
        {
                ApiPersonResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonRequestModel request);

                ApiPersonRequestModel MapResponseToRequest(
                        ApiPersonResponseModel response);

                JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>9831d576fe45eac0d0531fc2d314f8be</Hash>
</Codenesium>*/