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
    <Hash>beca818a00f4a424bd039edeb9c00ff6</Hash>
</Codenesium>*/