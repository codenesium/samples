using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiEventRelatedDocumentModelMapper
        {
                ApiEventRelatedDocumentResponseModel MapRequestToResponse(
                        int id,
                        ApiEventRelatedDocumentRequestModel request);

                ApiEventRelatedDocumentRequestModel MapResponseToRequest(
                        ApiEventRelatedDocumentResponseModel response);

                JsonPatchDocument<ApiEventRelatedDocumentRequestModel> CreatePatch(ApiEventRelatedDocumentRequestModel model);
        }
}

/*<Codenesium>
    <Hash>53f5944f1d538c0b77550c45036325e7</Hash>
</Codenesium>*/