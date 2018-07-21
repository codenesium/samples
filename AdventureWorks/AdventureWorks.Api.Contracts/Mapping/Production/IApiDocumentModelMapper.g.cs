using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiDocumentModelMapper
        {
                ApiDocumentResponseModel MapRequestToResponse(
                        Guid rowguid,
                        ApiDocumentRequestModel request);

                ApiDocumentRequestModel MapResponseToRequest(
                        ApiDocumentResponseModel response);

                JsonPatchDocument<ApiDocumentRequestModel> CreatePatch(ApiDocumentRequestModel model);
        }
}

/*<Codenesium>
    <Hash>3374fed7e65282cdc619d31a661788d5</Hash>
</Codenesium>*/