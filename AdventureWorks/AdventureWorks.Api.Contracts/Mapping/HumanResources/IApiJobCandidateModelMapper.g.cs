using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiJobCandidateModelMapper
        {
                ApiJobCandidateResponseModel MapRequestToResponse(
                        int jobCandidateID,
                        ApiJobCandidateRequestModel request);

                ApiJobCandidateRequestModel MapResponseToRequest(
                        ApiJobCandidateResponseModel response);

                JsonPatchDocument<ApiJobCandidateRequestModel> CreatePatch(ApiJobCandidateRequestModel model);
        }
}

/*<Codenesium>
    <Hash>de069690f1472c1cfa0b68cb136c78e5</Hash>
</Codenesium>*/