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
			ApiPurchaseOrderHeaderServerRequestModel model);

		ApiPurchaseOrderHeaderServerResponseModel MapBOToModel(
			BOPurchaseOrderHeader boPurchaseOrderHeader);

		List<ApiPurchaseOrderHeaderServerResponseModel> MapBOToModel(
			List<BOPurchaseOrderHeader> items);
	}
}

/*<Codenesium>
    <Hash>a6ffb8e2300a058cef17b3d4f76201d0</Hash>
</Codenesium>*/