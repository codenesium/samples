using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLPurchaseOrderHeaderMapper
        {
                BOPurchaseOrderHeader MapModelToBO(
                        int purchaseOrderID,
                        ApiPurchaseOrderHeaderRequestModel model);

                ApiPurchaseOrderHeaderResponseModel MapBOToModel(
                        BOPurchaseOrderHeader boPurchaseOrderHeader);

                List<ApiPurchaseOrderHeaderResponseModel> MapBOToModel(
                        List<BOPurchaseOrderHeader> items);
        }
}

/*<Codenesium>
    <Hash>4c51814f31f8cb920e5a60e0bc6a3c6a</Hash>
</Codenesium>*/