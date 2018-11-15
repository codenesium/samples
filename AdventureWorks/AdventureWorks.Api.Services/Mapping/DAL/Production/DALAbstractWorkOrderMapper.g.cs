using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractWorkOrderMapper
	{
		public virtual WorkOrder MapBOToEF(
			BOWorkOrder bo)
		{
			WorkOrder efWorkOrder = new WorkOrder();
			efWorkOrder.SetProperties(
				bo.DueDate,
				bo.EndDate,
				bo.ModifiedDate,
				bo.OrderQty,
				bo.ProductID,
				bo.ScrappedQty,
				bo.ScrapReasonID,
				bo.StartDate,
				bo.StockedQty,
				bo.WorkOrderID);
			return efWorkOrder;
		}

		public virtual BOWorkOrder MapEFToBO(
			WorkOrder ef)
		{
			var bo = new BOWorkOrder();

			bo.SetProperties(
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
			return bo;
		}

		public virtual List<BOWorkOrder> MapEFToBO(
			List<WorkOrder> records)
		{
			List<BOWorkOrder> response = new List<BOWorkOrder>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f343228047fa567cc6f94a8b45143b48</Hash>
</Codenesium>*/