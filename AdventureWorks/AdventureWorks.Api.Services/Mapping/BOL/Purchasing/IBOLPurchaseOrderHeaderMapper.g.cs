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
			List<BOPurchaseOrderHeader> bos);
	}
}

/*<Codenesium>
    <Hash>b17dbc9eaa863b0d2050824d9b4ecc6d</Hash>
</Codenesium>*/