using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesOrderHeaderMapper
	{
		public virtual SalesOrderHeader MapModelToBO(
			int salesOrderID,
			ApiSalesOrderHeaderServerRequestModel model
			)
		{
			SalesOrderHeader item = new SalesOrderHeader();
			item.SetProperties(
				salesOrderID,
				model.AccountNumber,
				model.BillToAddressID,
				model.Comment,
				model.CreditCardApprovalCode,
				model.CreditCardID,
				model.CurrencyRateID,
				model.CustomerID,
				model.DueDate,
				model.Freight,
				model.ModifiedDate,
				model.OnlineOrderFlag,
				model.OrderDate,
				model.PurchaseOrderNumber,
				model.RevisionNumber,
				model.Rowguid,
				model.SalesOrderNumber,
				model.SalesPersonID,
				model.ShipDate,
				model.ShipMethodID,
				model.ShipToAddressID,
				model.Status,
				model.SubTotal,
				model.TaxAmt,
				model.TerritoryID,
				model.TotalDue);
			return item;
		}

		public virtual ApiSalesOrderHeaderServerResponseModel MapBOToModel(
			SalesOrderHeader item)
		{
			var model = new ApiSalesOrderHeaderServerResponseModel();

			model.SetProperties(item.SalesOrderID, item.AccountNumber, item.BillToAddressID, item.Comment, item.CreditCardApprovalCode, item.CreditCardID, item.CurrencyRateID, item.CustomerID, item.DueDate, item.Freight, item.ModifiedDate, item.OnlineOrderFlag, item.OrderDate, item.PurchaseOrderNumber, item.RevisionNumber, item.Rowguid, item.SalesOrderNumber, item.SalesPersonID, item.ShipDate, item.ShipMethodID, item.ShipToAddressID, item.Status, item.SubTotal, item.TaxAmt, item.TerritoryID, item.TotalDue);

			return model;
		}

		public virtual List<ApiSalesOrderHeaderServerResponseModel> MapBOToModel(
			List<SalesOrderHeader> items)
		{
			List<ApiSalesOrderHeaderServerResponseModel> response = new List<ApiSalesOrderHeaderServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e59b89c8be3bb5956f69d8e13915062b</Hash>
</Codenesium>*/