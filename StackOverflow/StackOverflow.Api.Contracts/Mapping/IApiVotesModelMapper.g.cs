using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiVotesModelMapper
        {
                ApiVotesResponseModel MapRequestToResponse(
                        int id,
                        ApiVotesRequestModel request);

                ApiVotesRequestModel MapResponseToRequest(
                        ApiVotesResponseModel response);
        }
}

/*<Codenesium>
    <Hash>89fcd61f6c7e9ec034548912257bdc38</Hash>
</Codenesium>*/