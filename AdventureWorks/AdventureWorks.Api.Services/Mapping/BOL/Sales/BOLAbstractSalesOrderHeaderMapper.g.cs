using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesOrderHeaderMapper
	{
		public virtual BOSalesOrderHeader MapModelToBO(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model
			)
		{
			BOSalesOrderHeader BOSalesOrderHeader = new BOSalesOrderHeader();

			BOSalesOrderHeader.SetProperties(
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
			return BOSalesOrderHeader;
		}

		public virtual ApiSalesOrderHeaderResponseModel MapBOToModel(
			BOSalesOrderHeader BOSalesOrderHeader)
		{
			if (BOSalesOrderHeader == null)
			{
				return null;
			}

			var model = new ApiSalesOrderHeaderResponseModel();

			model.SetProperties(BOSalesOrderHeader.AccountNumber, BOSalesOrderHeader.BillToAddressID, BOSalesOrderHeader.Comment, BOSalesOrderHeader.CreditCardApprovalCode, BOSalesOrderHeader.CreditCardID, BOSalesOrderHeader.CurrencyRateID, BOSalesOrderHeader.CustomerID, BOSalesOrderHeader.DueDate, BOSalesOrderHeader.Freight, BOSalesOrderHeader.ModifiedDate, BOSalesOrderHeader.OnlineOrderFlag, BOSalesOrderHeader.OrderDate, BOSalesOrderHeader.PurchaseOrderNumber, BOSalesOrderHeader.RevisionNumber, BOSalesOrderHeader.Rowguid, BOSalesOrderHeader.SalesOrderID, BOSalesOrderHeader.SalesOrderNumber, BOSalesOrderHeader.SalesPersonID, BOSalesOrderHeader.ShipDate, BOSalesOrderHeader.ShipMethodID, BOSalesOrderHeader.ShipToAddressID, BOSalesOrderHeader.Status, BOSalesOrderHeader.SubTotal, BOSalesOrderHeader.TaxAmt, BOSalesOrderHeader.TerritoryID, BOSalesOrderHeader.TotalDue);

			return model;
		}

		public virtual List<ApiSalesOrderHeaderResponseModel> MapBOToModel(
			List<BOSalesOrderHeader> BOs)
		{
			List<ApiSalesOrderHeaderResponseModel> response = new List<ApiSalesOrderHeaderResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>23e545bb7782a51b83cefa66192081ce</Hash>
</Codenesium>*/