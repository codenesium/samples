using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPurchaseOrderHeaderMapper
	{
		public virtual DTOPurchaseOrderHeader MapModelToDTO(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel model
			)
		{
			DTOPurchaseOrderHeader dtoPurchaseOrderHeader = new DTOPurchaseOrderHeader();

			dtoPurchaseOrderHeader.SetProperties(
				purchaseOrderID,
				model.EmployeeID,
				model.Freight,
				model.ModifiedDate,
				model.OrderDate,
				model.RevisionNumber,
				model.ShipDate,
				model.ShipMethodID,
				model.Status,
				model.SubTotal,
				model.TaxAmt,
				model.TotalDue,
				model.VendorID);
			return dtoPurchaseOrderHeader;
		}

		public virtual ApiPurchaseOrderHeaderResponseModel MapDTOToModel(
			DTOPurchaseOrderHeader dtoPurchaseOrderHeader)
		{
			if (dtoPurchaseOrderHeader == null)
			{
				return null;
			}

			var model = new ApiPurchaseOrderHeaderResponseModel();

			model.SetProperties(dtoPurchaseOrderHeader.EmployeeID, dtoPurchaseOrderHeader.Freight, dtoPurchaseOrderHeader.ModifiedDate, dtoPurchaseOrderHeader.OrderDate, dtoPurchaseOrderHeader.PurchaseOrderID, dtoPurchaseOrderHeader.RevisionNumber, dtoPurchaseOrderHeader.ShipDate, dtoPurchaseOrderHeader.ShipMethodID, dtoPurchaseOrderHeader.Status, dtoPurchaseOrderHeader.SubTotal, dtoPurchaseOrderHeader.TaxAmt, dtoPurchaseOrderHeader.TotalDue, dtoPurchaseOrderHeader.VendorID);

			return model;
		}

		public virtual List<ApiPurchaseOrderHeaderResponseModel> MapDTOToModel(
			List<DTOPurchaseOrderHeader> dtos)
		{
			List<ApiPurchaseOrderHeaderResponseModel> response = new List<ApiPurchaseOrderHeaderResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cfa7db574e5abdd002775b9c3557c91f</Hash>
</Codenesium>*/