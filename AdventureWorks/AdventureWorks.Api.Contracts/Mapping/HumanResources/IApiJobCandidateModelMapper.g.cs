using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiJobCandidateModelMapper
        {
                ApiJobCandidateResponseModel MapRequestToResponse(
                        int jobCandidateID,
                        ApiJobCandidateRequestModel request);

                ApiJobCandidateRequestModel MapResponseToRequest(
                        ApiJobCandidateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>bc667b96986344d51d037d114b0518b1</Hash>
</Codenesium>*/