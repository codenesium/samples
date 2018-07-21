using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPurchaseOrderDetailModelMapper
        {
                ApiPurchaseOrderDetailResponseModel MapRequestToResponse(
                        int purchaseOrderID,
                        ApiPurchaseOrderDetailRequestModel request);

                ApiPurchaseOrderDetailRequestModel MapResponseToRequest(
                        ApiPurchaseOrderDetailResponseModel response);

                JsonPatchDocument<ApiPurchaseOrderDetailRequestModel> CreatePatch(ApiPurchaseOrderDetailRequestModel model);
        }
}

/*<Codenesium>
    <Hash>2969efdc31faf56efcab281332f0f2e1</Hash>
</Codenesium>*/