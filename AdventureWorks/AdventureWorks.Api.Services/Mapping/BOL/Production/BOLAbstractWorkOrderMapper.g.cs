using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractWorkOrderMapper
	{
		public virtual BOWorkOrder MapModelToBO(
			int workOrderID,
			ApiWorkOrderRequestModel model
			)
		{
			BOWorkOrder boWorkOrder = new BOWorkOrder();
			boWorkOrder.SetProperties(
				workOrderID,
				model.DueDate,
				model.EndDate,
				model.ModifiedDate,
				model.OrderQty,
				model.ProductID,
				model.ScrappedQty,
				model.ScrapReasonID,
				model.StartDate,
				model.StockedQty);
			return boWorkOrder;
		}

		public virtual ApiWorkOrderResponseModel MapBOToModel(
			BOWorkOrder boWorkOrder)
		{
			var model = new ApiWorkOrderResponseModel();

			model.SetProperties(boWorkOrder.WorkOrderID, boWorkOrder.DueDate, boWorkOrder.EndDate, boWorkOrder.ModifiedDate, boWorkOrder.OrderQty, boWorkOrder.ProductID, boWorkOrder.ScrappedQty, boWorkOrder.ScrapReasonID, boWorkOrder.StartDate, boWorkOrder.StockedQty);

			return model;
		}

		public virtual List<ApiWorkOrderResponseModel> MapBOToModel(
			List<BOWorkOrder> items)
		{
			List<ApiWorkOrderResponseModel> response = new List<ApiWorkOrderResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0b2ccf9763665c74b703ca6a16bdd8bb</Hash>
</Codenesium>*/