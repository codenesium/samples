using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALWorkOrderMapper
	{
		public virtual WorkOrder MapModelToEntity(
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

		public virtual ApiWorkOrderServerResponseModel MapEntityToModel(
			WorkOrder item)
		{
			var model = new ApiWorkOrderServerResponseModel();

			model.SetProperties(item.WorkOrderID,
			                    item.DueDate,
			                    item.EndDate,
			                    item.ModifiedDate,
			                    item.OrderQty,
			                    item.ProductID,
			                    item.ScrappedQty,
			                    item.ScrapReasonID,
			                    item.StartDate,
			                    item.StockedQty);

			return model;
		}

		public virtual List<ApiWorkOrderServerResponseModel> MapEntityToModel(
			List<WorkOrder> items)
		{
			List<ApiWorkOrderServerResponseModel> response = new List<ApiWorkOrderServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>589229b419bfcaf87e162bedeb65ac4e</Hash>
</Codenesium>*/