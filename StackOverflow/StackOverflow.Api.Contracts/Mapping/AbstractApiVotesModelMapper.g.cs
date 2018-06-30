using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiVotesModelMapper
        {
                public virtual ApiVotesResponseModel MapRequestToResponse(
                        int id,
                        ApiVotesRequestModel request)
                {
                        var response = new ApiVotesResponseModel();
                        response.SetProperties(id,
                                               request.BountyAmount,
                                               request.CreationDate,
                                               request.PostId,
                                               request.UserId,
                                               request.VoteTypeId);
                        return response;
                }

                public virtual ApiVotesRequestModel MapResponseToRequest(
                        ApiVotesResponseModel response)
                {
                        var request = new ApiVotesRequestModel();
                        request.SetProperties(
                                response.BountyAmount,
                                response.CreationDate,
                                response.PostId,
                                response.UserId,
                                response.VoteTypeId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>6af7d1832f00eb02ab72334cc0778426</Hash>
</Codenesium>*/