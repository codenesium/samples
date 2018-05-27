using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPurchaseOrderDetailMapper
	{
		public virtual DTOPurchaseOrderDetail MapModelToDTO(
			int purchaseOrderID,
			ApiPurchaseOrderDetailRequestModel model
			)
		{
			DTOPurchaseOrderDetail dtoPurchaseOrderDetail = new DTOPurchaseOrderDetail();

			dtoPurchaseOrderDetail.SetProperties(
				purchaseOrderID,
				model.DueDate,
				model.LineTotal,
				model.ModifiedDate,
				model.OrderQty,
				model.ProductID,
				model.PurchaseOrderDetailID,
				model.ReceivedQty,
				model.RejectedQty,
				model.StockedQty,
				model.UnitPrice);
			return dtoPurchaseOrderDetail;
		}

		public virtual ApiPurchaseOrderDetailResponseModel MapDTOToModel(
			DTOPurchaseOrderDetail dtoPurchaseOrderDetail)
		{
			if (dtoPurchaseOrderDetail == null)
			{
				return null;
			}

			var model = new ApiPurchaseOrderDetailResponseModel();

			model.SetProperties(dtoPurchaseOrderDetail.DueDate, dtoPurchaseOrderDetail.LineTotal, dtoPurchaseOrderDetail.ModifiedDate, dtoPurchaseOrderDetail.OrderQty, dtoPurchaseOrderDetail.ProductID, dtoPurchaseOrderDetail.PurchaseOrderDetailID, dtoPurchaseOrderDetail.PurchaseOrderID, dtoPurchaseOrderDetail.ReceivedQty, dtoPurchaseOrderDetail.RejectedQty, dtoPurchaseOrderDetail.StockedQty, dtoPurchaseOrderDetail.UnitPrice);

			return model;
		}

		public virtual List<ApiPurchaseOrderDetailResponseModel> MapDTOToModel(
			List<DTOPurchaseOrderDetail> dtos)
		{
			List<ApiPurchaseOrderDetailResponseModel> response = new List<ApiPurchaseOrderDetailResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>822a84dc9de21eda844e0875e8e996e4</Hash>
</Codenesium>*/