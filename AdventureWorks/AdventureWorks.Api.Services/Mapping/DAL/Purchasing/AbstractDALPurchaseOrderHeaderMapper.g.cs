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
			if (item.ShipMethodIDNavigation != null)
			{
				var shipMethodIDModel = new ApiShipMethodServerResponseModel();
				shipMethodIDModel.SetProperties(
					item.ShipMethodIDNavigation.ShipMethodID,
					item.ShipMethodIDNavigation.ModifiedDate,
					item.ShipMethodIDNavigation.Name,
					item.ShipMethodIDNavigation.Rowguid,
					item.ShipMethodIDNavigation.ShipBase,
					item.ShipMethodIDNavigation.ShipRate);

				model.SetShipMethodIDNavigation(shipMethodIDModel);
			}

			if (item.VendorIDNavigation != null)
			{
				var vendorIDModel = new ApiVendorServerResponseModel();
				vendorIDModel.SetProperties(
					item.VendorIDNavigation.BusinessEntityID,
					item.VendorIDNavigation.AccountNumber,
					item.VendorIDNavigation.ActiveFlag,
					item.VendorIDNavigation.CreditRating,
					item.VendorIDNavigation.ModifiedDate,
					item.VendorIDNavigation.Name,
					item.VendorIDNavigation.PreferredVendorStatu,
					item.VendorIDNavigation.PurchasingWebServiceURL);

				model.SetVendorIDNavigation(vendorIDModel);
			}

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
    <Hash>a1fd2d89d545b69b159f7543d7c4407c</Hash>
</Codenesium>*/