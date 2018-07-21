using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepModelMapper
        {
                public virtual ApiPipelineStepResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepRequestModel request)
                {
                        var response = new ApiPipelineStepResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.PipelineStepStatusId,
                                               request.ShipperId);
                        return response;
                }

                public virtual ApiPipelineStepRequestModel MapResponseToRequest(
                        ApiPipelineStepResponseModel response)
                {
                        var request = new ApiPipelineStepRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.PipelineStepStatusId,
                                response.ShipperId);
                        return request;
                }

                public JsonPatchDocument<ApiPipelineStepRequestModel> CreatePatch(ApiPipelineStepRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPipelineStepRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        patch.Replace(x => x.PipelineStepStatusId, model.PipelineStepStatusId);
                        patch.Replace(x => x.ShipperId, model.ShipperId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>4828aa00d458162fa6c1a36e96eec298</Hash>
</Codenesium>*/