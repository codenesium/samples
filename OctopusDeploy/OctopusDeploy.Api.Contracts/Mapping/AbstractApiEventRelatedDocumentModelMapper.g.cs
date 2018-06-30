using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiEventRelatedDocumentModelMapper
        {
                public virtual ApiEventRelatedDocumentResponseModel MapRequestToResponse(
                        int id,
                        ApiEventRelatedDocumentRequestModel request)
                {
                        var response = new ApiEventRelatedDocumentResponseModel();
                        response.SetProperties(id,
                                               request.EventId,
                                               request.RelatedDocumentId);
                        return response;
                }

                public virtual ApiEventRelatedDocumentRequestModel MapResponseToRequest(
                        ApiEventRelatedDocumentResponseModel response)
                {
                        var request = new ApiEventRelatedDocumentRequestModel();
                        request.SetProperties(
                                response.EventId,
                                response.RelatedDocumentId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>915f6d6f085e08c4c5894d641dca89a2</Hash>
</Codenesium>*/