using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPurchaseOrderHeaderModelMapper
        {
                ApiPurchaseOrderHeaderResponseModel MapRequestToResponse(
                        int purchaseOrderID,
                        ApiPurchaseOrderHeaderRequestModel request);

                ApiPurchaseOrderHeaderRequestModel MapResponseToRequest(
                        ApiPurchaseOrderHeaderResponseModel response);

                JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel> CreatePatch(ApiPurchaseOrderHeaderRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e51ce598bae55ce9519606d4d7d4bd67</Hash>
</Codenesium>*/