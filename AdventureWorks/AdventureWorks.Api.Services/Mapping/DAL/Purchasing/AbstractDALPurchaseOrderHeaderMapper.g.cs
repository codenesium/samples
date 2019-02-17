using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPurchaseOrderHeaderMapper
	{
		public virtual PurchaseOrderHeader MapModelToEntity(
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

		public virtual ApiPurchaseOrderHeaderServerResponseModel MapEntityToModel(
			PurchaseOrderHeader item)
		{
			var model = new ApiPurchaseOrderHeaderServerResponseModel();

			model.SetProperties(item.PurchaseOrderID,
			                    item.EmployeeID,
			                    item.Freight,
			                    item.ModifiedDate,
			                    item.OrderDate,
			                    item.RevisionNumber,
			                    item.ShipDate,
			                    item.ShipMethodID,
			                    item.Status,
			                    item.SubTotal,
			                    item.TaxAmt,
			                    item.TotalDue,
			                    item.VendorID);

			return model;
		}

		public virtual List<ApiPurchaseOrderHeaderServerResponseModel> MapEntityToModel(
			List<PurchaseOrderHeader> items)
		{
			List<ApiPurchaseOrderHeaderServerResponseModel> response = new List<ApiPurchaseOrderHeaderServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d1deb7723ef1df27222ef30c2b112b19</Hash>
</Codenesium>*/