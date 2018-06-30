using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineModelMapper
        {
                ApiPipelineResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineRequestModel request);

                ApiPipelineRequestModel MapResponseToRequest(
                        ApiPipelineResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d4142d3cec66d8b4416ff81d49ad6370</Hash>
</Codenesium>*/