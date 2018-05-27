using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLPurchaseOrderDetailMapper
	{
		DTOPurchaseOrderDetail MapModelToDTO(
			int purchaseOrderID,
			ApiPurchaseOrderDetailRequestModel model);

		ApiPurchaseOrderDetailResponseModel MapDTOToModel(
			DTOPurchaseOrderDetail dtoPurchaseOrderDetail);

		List<ApiPurchaseOrderDetailResponseModel> MapDTOToModel(
			List<DTOPurchaseOrderDetail> dtos);
	}
}

/*<Codenesium>
    <Hash>0971059a01384229d38bcf360f5f1f66</Hash>
</Codenesium>*/