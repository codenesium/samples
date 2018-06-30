using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiPurchaseOrderHeaderModelMapper
        {
                ApiPurchaseOrderHeaderResponseModel MapRequestToResponse(
                        int purchaseOrderID,
                        ApiPurchaseOrderHeaderRequestModel request);

                ApiPurchaseOrderHeaderRequestModel MapResponseToRequest(
                        ApiPurchaseOrderHeaderResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0a97964518ce60014e284147feaeb557</Hash>
</Codenesium>*/