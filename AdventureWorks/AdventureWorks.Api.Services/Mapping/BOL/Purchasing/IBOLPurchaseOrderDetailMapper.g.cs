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
    <Hash>521d60f32b15bca2a35327870eda55e0</Hash>
</Codenesium>*/