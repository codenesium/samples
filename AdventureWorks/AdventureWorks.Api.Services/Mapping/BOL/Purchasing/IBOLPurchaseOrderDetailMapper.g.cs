using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>dcde30fb8ec1a865ad8d2c2bfca2ea7b</Hash>
</Codenesium>*/