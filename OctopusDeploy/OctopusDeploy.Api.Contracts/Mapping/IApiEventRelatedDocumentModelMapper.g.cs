using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiEventRelatedDocumentModelMapper
        {
                ApiEventRelatedDocumentResponseModel MapRequestToResponse(
                        int id,
                        ApiEventRelatedDocumentRequestModel request);

                ApiEventRelatedDocumentRequestModel MapResponseToRequest(
                        ApiEventRelatedDocumentResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9f8636e930c8dea2831d60ac6e57180d</Hash>
</Codenesium>*/