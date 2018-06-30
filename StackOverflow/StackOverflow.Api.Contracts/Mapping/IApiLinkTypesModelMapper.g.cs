using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiLinkTypesModelMapper
        {
                ApiLinkTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkTypesRequestModel request);

                ApiLinkTypesRequestModel MapResponseToRequest(
                        ApiLinkTypesResponseModel response);
        }
}

/*<Codenesium>
    <Hash>30f193797faf3017da87348b503f1ec8</Hash>
</Codenesium>*/