using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALWorkOrderMapper
	{
		public virtual void MapDTOToEF(
			int workOrderID,
			DTOWorkOrder dto,
			WorkOrder efWorkOrder)
		{
			efWorkOrder.SetProperties(
				workOrderID,
				dto.DueDate,
				dto.EndDate,
				dto.ModifiedDate,
				dto.OrderQty,
				dto.ProductID,
				dto.ScrappedQty,
				dto.ScrapReasonID,
				dto.StartDate,
				dto.StockedQty);
		}

		public virtual DTOWorkOrder MapEFToDTO(
			WorkOrder ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOWorkOrder();

			dto.SetProperties(
				ef.WorkOrderID,
				ef.DueDate,
				ef.EndDate,
				ef.ModifiedDate,
				ef.OrderQty,
				ef.ProductID,
				ef.ScrappedQty,
				ef.ScrapReasonID,
				ef.StartDate,
				ef.StockedQty);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>cf754b3ac071bbfb8c4fb60acab556ec</Hash>
</Codenesium>*/