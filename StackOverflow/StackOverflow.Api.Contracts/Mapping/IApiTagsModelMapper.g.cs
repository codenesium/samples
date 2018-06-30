using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiTagsModelMapper
        {
                ApiTagsResponseModel MapRequestToResponse(
                        int id,
                        ApiTagsRequestModel request);

                ApiTagsRequestModel MapResponseToRequest(
                        ApiTagsResponseModel response);
        }
}

/*<Codenesium>
    <Hash>328011421c0019f4889f5c9106a6ed95</Hash>
</Codenesium>*/