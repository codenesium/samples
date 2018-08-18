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
    <Hash>f3998a681d28506ba8ef9628434da64a</Hash>
</Codenesium>*/