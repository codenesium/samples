using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLPurchaseOrderDetailMapper
        {
                BOPurchaseOrderDetail MapModelToBO(
                        int purchaseOrderID,
                        ApiPurchaseOrderDetailRequestModel model);

                ApiPurchaseOrderDetailResponseModel MapBOToModel(
                        BOPurchaseOrderDetail boPurchaseOrderDetail);

                List<ApiPurchaseOrderDetailResponseModel> MapBOToModel(
                        List<BOPurchaseOrderDetail> items);
        }
}

/*<Codenesium>
    <Hash>975895c5469b48d64efad3b87dc2dc85</Hash>
</Codenesium>*/