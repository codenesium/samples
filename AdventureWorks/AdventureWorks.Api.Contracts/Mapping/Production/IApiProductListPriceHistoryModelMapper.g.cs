using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductListPriceHistoryModelMapper
        {
                ApiProductListPriceHistoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductListPriceHistoryRequestModel request);

                ApiProductListPriceHistoryRequestModel MapResponseToRequest(
                        ApiProductListPriceHistoryResponseModel response);

                JsonPatchDocument<ApiProductListPriceHistoryRequestModel> CreatePatch(ApiProductListPriceHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>939c89e55ce2dede051bfbe6f49c9aa3</Hash>
</Codenesium>*/