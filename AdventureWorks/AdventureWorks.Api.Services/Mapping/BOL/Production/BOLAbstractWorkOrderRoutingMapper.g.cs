using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractWorkOrderRoutingMapper
	{
		public virtual BOWorkOrderRouting MapModelToBO(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel model
			)
		{
			BOWorkOrderRouting BOWorkOrderRouting = new BOWorkOrderRouting();

			BOWorkOrderRouting.SetProperties(
				workOrderID,
				model.ActualCost,
				model.ActualEndDate,
				model.ActualResourceHrs,
				model.ActualStartDate,
				model.LocationID,
				model.ModifiedDate,
				model.OperationSequence,
				model.PlannedCost,
				model.ProductID,
				model.ScheduledEndDate,
				model.ScheduledStartDate);
			return BOWorkOrderRouting;
		}

		public virtual ApiWorkOrderRoutingResponseModel MapBOToModel(
			BOWorkOrderRouting BOWorkOrderRouting)
		{
			if (BOWorkOrderRouting == null)
			{
				return null;
			}

			var model = new ApiWorkOrderRoutingResponseModel();

			model.SetProperties(BOWorkOrderRouting.ActualCost, BOWorkOrderRouting.ActualEndDate, BOWorkOrderRouting.ActualResourceHrs, BOWorkOrderRouting.ActualStartDate, BOWorkOrderRouting.LocationID, BOWorkOrderRouting.ModifiedDate, BOWorkOrderRouting.OperationSequence, BOWorkOrderRouting.PlannedCost, BOWorkOrderRouting.ProductID, BOWorkOrderRouting.ScheduledEndDate, BOWorkOrderRouting.ScheduledStartDate, BOWorkOrderRouting.WorkOrderID);

			return model;
		}

		public virtual List<ApiWorkOrderRoutingResponseModel> MapBOToModel(
			List<BOWorkOrderRouting> BOs)
		{
			List<ApiWorkOrderRoutingResponseModel> response = new List<ApiWorkOrderRoutingResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a3ee96bb3c80c977a289772cfdbfd4bc</Hash>
</Codenesium>*/