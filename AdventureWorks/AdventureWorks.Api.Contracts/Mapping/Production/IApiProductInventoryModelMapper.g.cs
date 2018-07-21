using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductInventoryModelMapper
        {
                ApiProductInventoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductInventoryRequestModel request);

                ApiProductInventoryRequestModel MapResponseToRequest(
                        ApiProductInventoryResponseModel response);

                JsonPatchDocument<ApiProductInventoryRequestModel> CreatePatch(ApiProductInventoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>4865863605b95c47ca863fe10e8e256a</Hash>
</Codenesium>*/