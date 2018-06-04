using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPurchaseOrderDetailMapper
	{
		public virtual BOPurchaseOrderDetail MapModelToBO(
			int purchaseOrderID,
			ApiPurchaseOrderDetailRequestModel model
			)
		{
			BOPurchaseOrderDetail BOPurchaseOrderDetail = new BOPurchaseOrderDetail();

			BOPurchaseOrderDetail.SetProperties(
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
			return BOPurchaseOrderDetail;
		}

		public virtual ApiPurchaseOrderDetailResponseModel MapBOToModel(
			BOPurchaseOrderDetail BOPurchaseOrderDetail)
		{
			if (BOPurchaseOrderDetail == null)
			{
				return null;
			}

			var model = new ApiPurchaseOrderDetailResponseModel();

			model.SetProperties(BOPurchaseOrderDetail.DueDate, BOPurchaseOrderDetail.LineTotal, BOPurchaseOrderDetail.ModifiedDate, BOPurchaseOrderDetail.OrderQty, BOPurchaseOrderDetail.ProductID, BOPurchaseOrderDetail.PurchaseOrderDetailID, BOPurchaseOrderDetail.PurchaseOrderID, BOPurchaseOrderDetail.ReceivedQty, BOPurchaseOrderDetail.RejectedQty, BOPurchaseOrderDetail.StockedQty, BOPurchaseOrderDetail.UnitPrice);

			return model;
		}

		public virtual List<ApiPurchaseOrderDetailResponseModel> MapBOToModel(
			List<BOPurchaseOrderDetail> BOs)
		{
			List<ApiPurchaseOrderDetailResponseModel> response = new List<ApiPurchaseOrderDetailResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>546895e8403ea71c2af7b438fe4afe15</Hash>
</Codenesium>*/