using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesPersonModelMapper
        {
                ApiSalesPersonResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesPersonRequestModel request);

                ApiSalesPersonRequestModel MapResponseToRequest(
                        ApiSalesPersonResponseModel response);

                JsonPatchDocument<ApiSalesPersonRequestModel> CreatePatch(ApiSalesPersonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b0a28aa5b02bd35bf3a47fb0a54047df</Hash>
</Codenesium>*/