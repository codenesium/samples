using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLWorkOrderRoutingMapper
	{
		public virtual DTOWorkOrderRouting MapModelToDTO(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel model
			)
		{
			DTOWorkOrderRouting dtoWorkOrderRouting = new DTOWorkOrderRouting();

			dtoWorkOrderRouting.SetProperties(
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
			return dtoWorkOrderRouting;
		}

		public virtual ApiWorkOrderRoutingResponseModel MapDTOToModel(
			DTOWorkOrderRouting dtoWorkOrderRouting)
		{
			if (dtoWorkOrderRouting == null)
			{
				return null;
			}

			var model = new ApiWorkOrderRoutingResponseModel();

			model.SetProperties(dtoWorkOrderRouting.ActualCost, dtoWorkOrderRouting.ActualEndDate, dtoWorkOrderRouting.ActualResourceHrs, dtoWorkOrderRouting.ActualStartDate, dtoWorkOrderRouting.LocationID, dtoWorkOrderRouting.ModifiedDate, dtoWorkOrderRouting.OperationSequence, dtoWorkOrderRouting.PlannedCost, dtoWorkOrderRouting.ProductID, dtoWorkOrderRouting.ScheduledEndDate, dtoWorkOrderRouting.ScheduledStartDate, dtoWorkOrderRouting.WorkOrderID);

			return model;
		}

		public virtual List<ApiWorkOrderRoutingResponseModel> MapDTOToModel(
			List<DTOWorkOrderRouting> dtos)
		{
			List<ApiWorkOrderRoutingResponseModel> response = new List<ApiWorkOrderRoutingResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>03b8f9317ec8eceacaf9ad20f61e348f</Hash>
</Codenesium>*/