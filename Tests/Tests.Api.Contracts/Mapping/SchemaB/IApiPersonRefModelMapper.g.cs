using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiPersonRefModelMapper
        {
                ApiPersonRefResponseModel MapRequestToResponse(
                        int id,
                        ApiPersonRefRequestModel request);

                ApiPersonRefRequestModel MapResponseToRequest(
                        ApiPersonRefResponseModel response);

                JsonPatchDocument<ApiPersonRefRequestModel> CreatePatch(ApiPersonRefRequestModel model);
        }
}

/*<Codenesium>
    <Hash>4c9e598fe19aae3df9ba28ea550c2faf</Hash>
</Codenesium>*/