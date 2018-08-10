using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPurchaseOrderHeaderMapper
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
    <Hash>d1db604b2f2119cf23ccb62b0cc74485</Hash>
</Codenesium>*/