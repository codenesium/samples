using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPurchaseOrderHeaderMapper
	{
		public virtual BOPurchaseOrderHeader MapModelToBO(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderServerRequestModel model
			)
		{
			BOPurchaseOrderHeader boPurchaseOrderHeader = new BOPurchaseOrderHeader();
			boPurchaseOrderHeader.SetProperties(
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
			return boPurchaseOrderHeader;
		}

		public virtual ApiPurchaseOrderHeaderServerResponseModel MapBOToModel(
			BOPurchaseOrderHeader boPurchaseOrderHeader)
		{
			var model = new ApiPurchaseOrderHeaderServerResponseModel();

			model.SetProperties(boPurchaseOrderHeader.PurchaseOrderID, boPurchaseOrderHeader.EmployeeID, boPurchaseOrderHeader.Freight, boPurchaseOrderHeader.ModifiedDate, boPurchaseOrderHeader.OrderDate, boPurchaseOrderHeader.RevisionNumber, boPurchaseOrderHeader.ShipDate, boPurchaseOrderHeader.ShipMethodID, boPurchaseOrderHeader.Status, boPurchaseOrderHeader.SubTotal, boPurchaseOrderHeader.TaxAmt, boPurchaseOrderHeader.TotalDue, boPurchaseOrderHeader.VendorID);

			return model;
		}

		public virtual List<ApiPurchaseOrderHeaderServerResponseModel> MapBOToModel(
			List<BOPurchaseOrderHeader> items)
		{
			List<ApiPurchaseOrderHeaderServerResponseModel> response = new List<ApiPurchaseOrderHeaderServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>272c9c1ef83532e719547b10be3a71fa</Hash>
</Codenesium>*/