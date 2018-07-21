using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepStepRequirementModelMapper
        {
                public virtual ApiPipelineStepStepRequirementResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepStepRequirementRequestModel request)
                {
                        var response = new ApiPipelineStepStepRequirementResponseModel();
                        response.SetProperties(id,
                                               request.Details,
                                               request.PipelineStepId,
                                               request.RequirementMet);
                        return response;
                }

                public virtual ApiPipelineStepStepRequirementRequestModel MapResponseToRequest(
                        ApiPipelineStepStepRequirementResponseModel response)
                {
                        var request = new ApiPipelineStepStepRequirementRequestModel();
                        request.SetProperties(
                                response.Details,
                                response.PipelineStepId,
                                response.RequirementMet);
                        return request;
                }

                public JsonPatchDocument<ApiPipelineStepStepRequirementRequestModel> CreatePatch(ApiPipelineStepStepRequirementRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPipelineStepStepRequirementRequestModel>();
                        patch.Replace(x => x.Details, model.Details);
                        patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
                        patch.Replace(x => x.RequirementMet, model.RequirementMet);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>5c8c419f7138861b91604eb732013c4c</Hash>
</Codenesium>*/