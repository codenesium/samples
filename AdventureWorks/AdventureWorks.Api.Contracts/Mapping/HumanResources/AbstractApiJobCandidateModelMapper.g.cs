using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiJobCandidateModelMapper
        {
                public virtual ApiJobCandidateResponseModel MapRequestToResponse(
                        int jobCandidateID,
                        ApiJobCandidateRequestModel request)
                {
                        var response = new ApiJobCandidateResponseModel();
                        response.SetProperties(jobCandidateID,
                                               request.BusinessEntityID,
                                               request.ModifiedDate,
                                               request.Resume);
                        return response;
                }

                public virtual ApiJobCandidateRequestModel MapResponseToRequest(
                        ApiJobCandidateResponseModel response)
                {
                        var request = new ApiJobCandidateRequestModel();
                        request.SetProperties(
                                response.BusinessEntityID,
                                response.ModifiedDate,
                                response.Resume);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>ae119323f94a7a222d2fe3967d00da7a</Hash>
</Codenesium>*/