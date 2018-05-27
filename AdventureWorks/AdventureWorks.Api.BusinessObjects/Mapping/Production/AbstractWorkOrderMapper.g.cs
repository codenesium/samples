using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLWorkOrderMapper
	{
		public virtual DTOWorkOrder MapModelToDTO(
			int workOrderID,
			ApiWorkOrderRequestModel model
			)
		{
			DTOWorkOrder dtoWorkOrder = new DTOWorkOrder();

			dtoWorkOrder.SetProperties(
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
			return dtoWorkOrder;
		}

		public virtual ApiWorkOrderResponseModel MapDTOToModel(
			DTOWorkOrder dtoWorkOrder)
		{
			if (dtoWorkOrder == null)
			{
				return null;
			}

			var model = new ApiWorkOrderResponseModel();

			model.SetProperties(dtoWorkOrder.DueDate, dtoWorkOrder.EndDate, dtoWorkOrder.ModifiedDate, dtoWorkOrder.OrderQty, dtoWorkOrder.ProductID, dtoWorkOrder.ScrappedQty, dtoWorkOrder.ScrapReasonID, dtoWorkOrder.StartDate, dtoWorkOrder.StockedQty, dtoWorkOrder.WorkOrderID);

			return model;
		}

		public virtual List<ApiWorkOrderResponseModel> MapDTOToModel(
			List<DTOWorkOrder> dtos)
		{
			List<ApiWorkOrderResponseModel> response = new List<ApiWorkOrderResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6cb1cb06a83024fe0275dae9f451498c</Hash>
</Codenesium>*/