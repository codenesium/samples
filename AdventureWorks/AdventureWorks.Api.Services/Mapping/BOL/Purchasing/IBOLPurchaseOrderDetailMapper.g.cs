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
    <Hash>e2622cc6711e9e7f03a5c1e478177e2d</Hash>
</Codenesium>*/