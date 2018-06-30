using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiTagsModelMapper
        {
                public virtual ApiTagsResponseModel MapRequestToResponse(
                        int id,
                        ApiTagsRequestModel request)
                {
                        var response = new ApiTagsResponseModel();
                        response.SetProperties(id,
                                               request.Count,
                                               request.ExcerptPostId,
                                               request.TagName,
                                               request.WikiPostId);
                        return response;
                }

                public virtual ApiTagsRequestModel MapResponseToRequest(
                        ApiTagsResponseModel response)
                {
                        var request = new ApiTagsRequestModel();
                        request.SetProperties(
                                response.Count,
                                response.ExcerptPostId,
                                response.TagName,
                                response.WikiPostId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>fa7c7a0a1a179250426aa49cbb99352a</Hash>
</Codenesium>*/