using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiLinkTypesModelMapper
        {
                public virtual ApiLinkTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkTypesRequestModel request)
                {
                        var response = new ApiLinkTypesResponseModel();
                        response.SetProperties(id,
                                               request.Type);
                        return response;
                }

                public virtual ApiLinkTypesRequestModel MapResponseToRequest(
                        ApiLinkTypesResponseModel response)
                {
                        var request = new ApiLinkTypesRequestModel();
                        request.SetProperties(
                                response.Type);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>8889c4d0a22d23e250be321b5aadccae</Hash>
</Codenesium>*/