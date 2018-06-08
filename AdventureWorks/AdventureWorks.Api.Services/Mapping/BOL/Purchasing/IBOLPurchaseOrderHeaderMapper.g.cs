using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>41abb03b0cdd2716a358811189037270</Hash>
</Codenesium>*/