using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineModelMapper
        {
                public virtual ApiPipelineResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineRequestModel request)
                {
                        var response = new ApiPipelineResponseModel();
                        response.SetProperties(id,
                                               request.PipelineStatusId,
                                               request.SaleId);
                        return response;
                }

                public virtual ApiPipelineRequestModel MapResponseToRequest(
                        ApiPipelineResponseModel response)
                {
                        var request = new ApiPipelineRequestModel();
                        request.SetProperties(
                                response.PipelineStatusId,
                                response.SaleId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>99f6c685ebf810dd0c1a2732e401cc19</Hash>
</Codenesium>*/