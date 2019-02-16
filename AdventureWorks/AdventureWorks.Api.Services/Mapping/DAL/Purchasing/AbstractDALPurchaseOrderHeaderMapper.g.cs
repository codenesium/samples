using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPurchaseOrderHeaderMapper
	{
		public virtual PurchaseOrderHeader MapModelToBO(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderServerRequestModel model
			)
		{
			PurchaseOrderHeader item = new PurchaseOrderHeader();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiPurchaseOrderHeaderServerResponseModel MapBOToModel(
			PurchaseOrderHeader item)
		{
			var model = new ApiPurchaseOrderHeaderServerResponseModel();

			model.SetProperties(item.PurchaseOrderID, item.EmployeeID, item.Freight, item.ModifiedDate, item.OrderDate, item.RevisionNumber, item.ShipDate, item.ShipMethodID, item.Status, item.SubTotal, item.TaxAmt, item.TotalDue, item.VendorID);

			return model;
		}

		public virtual List<ApiPurchaseOrderHeaderServerResponseModel> MapBOToModel(
			List<PurchaseOrderHeader> items)
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
    <Hash>4fc423589ed1cbeb468ce72afa6083b2</Hash>
</Codenesium>*/