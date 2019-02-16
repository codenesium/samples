using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALWorkOrderMapper
	{
		public virtual WorkOrder MapModelToBO(
			int workOrderID,
			ApiWorkOrderServerRequestModel model
			)
		{
			WorkOrder item = new WorkOrder();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiWorkOrderServerResponseModel MapBOToModel(
			WorkOrder item)
		{
			var model = new ApiWorkOrderServerResponseModel();

			model.SetProperties(item.WorkOrderID, item.DueDate, item.EndDate, item.ModifiedDate, item.OrderQty, item.ProductID, item.ScrappedQty, item.ScrapReasonID, item.StartDate, item.StockedQty);

			return model;
		}

		public virtual List<ApiWorkOrderServerResponseModel> MapBOToModel(
			List<WorkOrder> items)
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
    <Hash>a91d561b9d7042b0cea1ea806b6ea18f</Hash>
</Codenesium>*/