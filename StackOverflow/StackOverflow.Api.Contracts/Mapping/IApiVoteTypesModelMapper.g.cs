using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiVoteTypesModelMapper
        {
                ApiVoteTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiVoteTypesRequestModel request);

                ApiVoteTypesRequestModel MapResponseToRequest(
                        ApiVoteTypesResponseModel response);
        }
}

/*<Codenesium>
    <Hash>94164d8b36e84c1fbe0e2e2180a2cddf</Hash>
</Codenesium>*/