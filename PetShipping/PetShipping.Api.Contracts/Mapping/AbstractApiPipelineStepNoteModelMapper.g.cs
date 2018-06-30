using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepNoteModelMapper
        {
                public virtual ApiPipelineStepNoteResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepNoteRequestModel request)
                {
                        var response = new ApiPipelineStepNoteResponseModel();
                        response.SetProperties(id,
                                               request.EmployeeId,
                                               request.Note,
                                               request.PipelineStepId);
                        return response;
                }

                public virtual ApiPipelineStepNoteRequestModel MapResponseToRequest(
                        ApiPipelineStepNoteResponseModel response)
                {
                        var request = new ApiPipelineStepNoteRequestModel();
                        request.SetProperties(
                                response.EmployeeId,
                                response.Note,
                                response.PipelineStepId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>3490bd9d0d67e2962f3f1ecb12760311</Hash>
</Codenesium>*/