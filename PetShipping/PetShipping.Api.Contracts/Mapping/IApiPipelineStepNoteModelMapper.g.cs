using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepNoteModelMapper
        {
                ApiPipelineStepNoteResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepNoteRequestModel request);

                ApiPipelineStepNoteRequestModel MapResponseToRequest(
                        ApiPipelineStepNoteResponseModel response);

                JsonPatchDocument<ApiPipelineStepNoteRequestModel> CreatePatch(ApiPipelineStepNoteRequestModel model);
        }
}

/*<Codenesium>
    <Hash>6af07dbd1983633f5698aa50a4485c87</Hash>
</Codenesium>*/