using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALWorkOrderRoutingMapper
	{
		public virtual void MapDTOToEF(
			int workOrderID,
			DTOWorkOrderRouting dto,
			WorkOrderRouting efWorkOrderRouting)
		{
			efWorkOrderRouting.SetProperties(
				workOrderID,
				dto.ActualCost,
				dto.ActualEndDate,
				dto.ActualResourceHrs,
				dto.ActualStartDate,
				dto.LocationID,
				dto.ModifiedDate,
				dto.OperationSequence,
				dto.PlannedCost,
				dto.ProductID,
				dto.ScheduledEndDate,
				dto.ScheduledStartDate);
		}

		public virtual DTOWorkOrderRouting MapEFToDTO(
			WorkOrderRouting ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOWorkOrderRouting();

			dto.SetProperties(
				ef.WorkOrderID,
				ef.ActualCost,
				ef.ActualEndDate,
				ef.ActualResourceHrs,
				ef.ActualStartDate,
				ef.LocationID,
				ef.ModifiedDate,
				ef.OperationSequence,
				ef.PlannedCost,
				ef.ProductID,
				ef.ScheduledEndDate,
				ef.ScheduledStartDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>77a25a2cfc9bd1be7925d5a7320c9ab4</Hash>
</Codenesium>*/