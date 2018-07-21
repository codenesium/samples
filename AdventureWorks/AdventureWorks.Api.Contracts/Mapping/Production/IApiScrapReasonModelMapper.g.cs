using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiScrapReasonModelMapper
        {
                ApiScrapReasonResponseModel MapRequestToResponse(
                        short scrapReasonID,
                        ApiScrapReasonRequestModel request);

                ApiScrapReasonRequestModel MapResponseToRequest(
                        ApiScrapReasonResponseModel response);

                JsonPatchDocument<ApiScrapReasonRequestModel> CreatePatch(ApiScrapReasonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>8cfe303b6c6360e012b39cf97cd16db1</Hash>
</Codenesium>*/