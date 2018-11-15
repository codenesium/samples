using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractWorkOrderMapper
	{
		public virtual BOWorkOrder MapModelToBO(
			int workOrderID,
			ApiWorkOrderServerRequestModel model
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

		public virtual ApiWorkOrderServerResponseModel MapBOToModel(
			BOWorkOrder boWorkOrder)
		{
			var model = new ApiWorkOrderServerResponseModel();

			model.SetProperties(boWorkOrder.WorkOrderID, boWorkOrder.DueDate, boWorkOrder.EndDate, boWorkOrder.ModifiedDate, boWorkOrder.OrderQty, boWorkOrder.ProductID, boWorkOrder.ScrappedQty, boWorkOrder.ScrapReasonID, boWorkOrder.StartDate, boWorkOrder.StockedQty);

			return model;
		}

		public virtual List<ApiWorkOrderServerResponseModel> MapBOToModel(
			List<BOWorkOrder> items)
		{
			List<ApiWorkOrderServerResponseModel> response = new List<ApiWorkOrderServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e2250e95da1c341232fdc6e2137b664f</Hash>
</Codenesium>*/