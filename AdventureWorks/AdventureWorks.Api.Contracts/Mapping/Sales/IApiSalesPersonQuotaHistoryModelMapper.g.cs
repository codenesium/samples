using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesPersonQuotaHistoryModelMapper
        {
                ApiSalesPersonQuotaHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiSalesPersonQuotaHistoryRequestModel request);

                ApiSalesPersonQuotaHistoryRequestModel MapResponseToRequest(
                        ApiSalesPersonQuotaHistoryResponseModel response);

                JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel> CreatePatch(ApiSalesPersonQuotaHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>bc103de11857a2a6f8eba24ec468f248</Hash>
</Codenesium>*/