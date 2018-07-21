using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostsModelMapper
        {
                ApiPostsResponseModel MapRequestToResponse(
                        int id,
                        ApiPostsRequestModel request);

                ApiPostsRequestModel MapResponseToRequest(
                        ApiPostsResponseModel response);

                JsonPatchDocument<ApiPostsRequestModel> CreatePatch(ApiPostsRequestModel model);
        }
}

/*<Codenesium>
    <Hash>86f7b20bff737df1b878a024e55cbc96</Hash>
</Codenesium>*/