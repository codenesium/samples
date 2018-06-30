using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostsModelMapper
        {
                ApiPostsResponseModel MapRequestToResponse(
                        int id,
                        ApiPostsRequestModel request);

                ApiPostsRequestModel MapResponseToRequest(
                        ApiPostsResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1bee9036fd9fd428e41f7d08dbb32362</Hash>
</Codenesium>*/