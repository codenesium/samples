using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPurchaseOrderHeaderMapper
	{
		PurchaseOrderHeader MapModelToBO(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderServerRequestModel model);

		ApiPurchaseOrderHeaderServerResponseModel MapBOToModel(
			PurchaseOrderHeader item);

		List<ApiPurchaseOrderHeaderServerResponseModel> MapBOToModel(
			List<PurchaseOrderHeader> items);
	}
}

/*<Codenesium>
    <Hash>0501da6890516dde2901f0f77b505340</Hash>
</Codenesium>*/