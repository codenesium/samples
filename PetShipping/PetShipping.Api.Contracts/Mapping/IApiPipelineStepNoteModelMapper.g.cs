using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepNoteModelMapper
        {
                ApiPipelineStepNoteResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepNoteRequestModel request);

                ApiPipelineStepNoteRequestModel MapResponseToRequest(
                        ApiPipelineStepNoteResponseModel response);
        }
}

/*<Codenesium>
    <Hash>8f8bf211390d8709db8068dac548eedd</Hash>
</Codenesium>*/