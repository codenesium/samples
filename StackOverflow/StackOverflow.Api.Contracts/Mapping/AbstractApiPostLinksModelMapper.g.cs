using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiPostLinksModelMapper
        {
                public virtual ApiPostLinksResponseModel MapRequestToResponse(
                        int id,
                        ApiPostLinksRequestModel request)
                {
                        var response = new ApiPostLinksResponseModel();
                        response.SetProperties(id,
                                               request.CreationDate,
                                               request.LinkTypeId,
                                               request.PostId,
                                               request.RelatedPostId);
                        return response;
                }

                public virtual ApiPostLinksRequestModel MapResponseToRequest(
                        ApiPostLinksResponseModel response)
                {
                        var request = new ApiPostLinksRequestModel();
                        request.SetProperties(
                                response.CreationDate,
                                response.LinkTypeId,
                                response.PostId,
                                response.RelatedPostId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>37acb5a1b43602a66445bc892194ccbc</Hash>
</Codenesium>*/