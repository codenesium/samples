using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiVoteTypesModelMapper
        {
                public virtual ApiVoteTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiVoteTypesRequestModel request)
                {
                        var response = new ApiVoteTypesResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiVoteTypesRequestModel MapResponseToRequest(
                        ApiVoteTypesResponseModel response)
                {
                        var request = new ApiVoteTypesRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>3efe4d1c68bf60777600fc859fe818c3</Hash>
</Codenesium>*/