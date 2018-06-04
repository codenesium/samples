using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractWorkOrderMapper
	{
		public virtual BOWorkOrder MapModelToBO(
			int workOrderID,
			ApiWorkOrderRequestModel model
			)
		{
			BOWorkOrder BOWorkOrder = new BOWorkOrder();

			BOWorkOrder.SetProperties(
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
			return BOWorkOrder;
		}

		public virtual ApiWorkOrderResponseModel MapBOToModel(
			BOWorkOrder BOWorkOrder)
		{
			if (BOWorkOrder == null)
			{
				return null;
			}

			var model = new ApiWorkOrderResponseModel();

			model.SetProperties(BOWorkOrder.DueDate, BOWorkOrder.EndDate, BOWorkOrder.ModifiedDate, BOWorkOrder.OrderQty, BOWorkOrder.ProductID, BOWorkOrder.ScrappedQty, BOWorkOrder.ScrapReasonID, BOWorkOrder.StartDate, BOWorkOrder.StockedQty, BOWorkOrder.WorkOrderID);

			return model;
		}

		public virtual List<ApiWorkOrderResponseModel> MapBOToModel(
			List<BOWorkOrder> BOs)
		{
			List<ApiWorkOrderResponseModel> response = new List<ApiWorkOrderResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ef0f64c96e3c7ba986482090e77708fa</Hash>
</Codenesium>*/