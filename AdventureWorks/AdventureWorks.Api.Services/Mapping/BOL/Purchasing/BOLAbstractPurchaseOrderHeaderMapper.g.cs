using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPurchaseOrderHeaderMapper
	{
		public virtual BOPurchaseOrderHeader MapModelToBO(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel model
			)
		{
			BOPurchaseOrderHeader BOPurchaseOrderHeader = new BOPurchaseOrderHeader();

			BOPurchaseOrderHeader.SetProperties(
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
			return BOPurchaseOrderHeader;
		}

		public virtual ApiPurchaseOrderHeaderResponseModel MapBOToModel(
			BOPurchaseOrderHeader BOPurchaseOrderHeader)
		{
			if (BOPurchaseOrderHeader == null)
			{
				return null;
			}

			var model = new ApiPurchaseOrderHeaderResponseModel();

			model.SetProperties(BOPurchaseOrderHeader.EmployeeID, BOPurchaseOrderHeader.Freight, BOPurchaseOrderHeader.ModifiedDate, BOPurchaseOrderHeader.OrderDate, BOPurchaseOrderHeader.PurchaseOrderID, BOPurchaseOrderHeader.RevisionNumber, BOPurchaseOrderHeader.ShipDate, BOPurchaseOrderHeader.ShipMethodID, BOPurchaseOrderHeader.Status, BOPurchaseOrderHeader.SubTotal, BOPurchaseOrderHeader.TaxAmt, BOPurchaseOrderHeader.TotalDue, BOPurchaseOrderHeader.VendorID);

			return model;
		}

		public virtual List<ApiPurchaseOrderHeaderResponseModel> MapBOToModel(
			List<BOPurchaseOrderHeader> BOs)
		{
			List<ApiPurchaseOrderHeaderResponseModel> response = new List<ApiPurchaseOrderHeaderResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1f03dab3e54b6b3f43b1b0eee72045b8</Hash>
</Codenesium>*/