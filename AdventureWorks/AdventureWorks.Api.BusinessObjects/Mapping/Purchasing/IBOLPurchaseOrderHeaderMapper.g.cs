using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLPurchaseOrderHeaderMapper
	{
		DTOPurchaseOrderHeader MapModelToDTO(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel model);

		ApiPurchaseOrderHeaderResponseModel MapDTOToModel(
			DTOPurchaseOrderHeader dtoPurchaseOrderHeader);

		List<ApiPurchaseOrderHeaderResponseModel> MapDTOToModel(
			List<DTOPurchaseOrderHeader> dtos);
	}
}

/*<Codenesium>
    <Hash>31e35a566c59cf3f8e43f853ccfbc6de</Hash>
</Codenesium>*/