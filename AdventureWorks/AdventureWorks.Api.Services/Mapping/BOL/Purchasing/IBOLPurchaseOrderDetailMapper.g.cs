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
			List<BOPurchaseOrderDetail> bos);
	}
}

/*<Codenesium>
    <Hash>4618203f6ab06c6f2ac086b155e4fc1c</Hash>
</Codenesium>*/