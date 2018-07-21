using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductCostHistoryModelMapper
        {
                ApiProductCostHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductCostHistoryRequestModel request);

                ApiProductCostHistoryRequestModel MapResponseToRequest(
                        ApiProductCostHistoryResponseModel response);

                JsonPatchDocument<ApiProductCostHistoryRequestModel> CreatePatch(ApiProductCostHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7b4211f311edeaef15a4f6b3c20a8811</Hash>
</Codenesium>*/