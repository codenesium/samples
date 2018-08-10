using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPurchaseOrderDetailMapper
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
    <Hash>f82e0ba426d53bbe2fc4656c1c8448b0</Hash>
</Codenesium>*/