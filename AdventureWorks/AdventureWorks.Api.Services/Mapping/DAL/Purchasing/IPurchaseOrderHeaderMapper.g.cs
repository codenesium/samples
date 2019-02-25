using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPurchaseOrderHeaderMapper
	{
		PurchaseOrderHeader MapModelToEntity(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderServerRequestModel model);

		ApiPurchaseOrderHeaderServerResponseModel MapEntityToModel(
			PurchaseOrderHeader item);

		List<ApiPurchaseOrderHeaderServerResponseModel> MapEntityToModel(
			List<PurchaseOrderHeader> items);
	}
}

/*<Codenesium>
    <Hash>4b75ab5efe5c237c73d9691343e3079e</Hash>
</Codenesium>*/