using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPurchaseOrderDetailModelMapper
        {
                ApiPurchaseOrderDetailResponseModel MapRequestToResponse(
                        int purchaseOrderID,
                        ApiPurchaseOrderDetailRequestModel request);

                ApiPurchaseOrderDetailRequestModel MapResponseToRequest(
                        ApiPurchaseOrderDetailResponseModel response);
        }
}

/*<Codenesium>
    <Hash>079cb45644e9c9cd18a5298d260aa20a</Hash>
</Codenesium>*/