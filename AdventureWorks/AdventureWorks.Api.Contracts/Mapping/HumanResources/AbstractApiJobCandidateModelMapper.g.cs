using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiJobCandidateRequestModel> CreatePatch(ApiJobCandidateRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiJobCandidateRequestModel>();
                        patch.Replace(x => x.BusinessEntityID, model.BusinessEntityID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Resume, model.Resume);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>44e2b38fa71808de7a27d772e033e6d3</Hash>
</Codenesium>*/