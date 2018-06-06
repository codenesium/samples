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
    <Hash>3f7aa804307a12f8c311674381917e03</Hash>
</Codenesium>*/