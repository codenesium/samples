using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesOrderHeaderMapper
	{
		public virtual DTOSalesOrderHeader MapModelToDTO(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model
			)
		{
			DTOSalesOrderHeader dtoSalesOrderHeader = new DTOSalesOrderHeader();

			dtoSalesOrderHeader.SetProperties(
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
			return dtoSalesOrderHeader;
		}

		public virtual ApiSalesOrderHeaderResponseModel MapDTOToModel(
			DTOSalesOrderHeader dtoSalesOrderHeader)
		{
			if (dtoSalesOrderHeader == null)
			{
				return null;
			}

			var model = new ApiSalesOrderHeaderResponseModel();

			model.SetProperties(dtoSalesOrderHeader.AccountNumber, dtoSalesOrderHeader.BillToAddressID, dtoSalesOrderHeader.Comment, dtoSalesOrderHeader.CreditCardApprovalCode, dtoSalesOrderHeader.CreditCardID, dtoSalesOrderHeader.CurrencyRateID, dtoSalesOrderHeader.CustomerID, dtoSalesOrderHeader.DueDate, dtoSalesOrderHeader.Freight, dtoSalesOrderHeader.ModifiedDate, dtoSalesOrderHeader.OnlineOrderFlag, dtoSalesOrderHeader.OrderDate, dtoSalesOrderHeader.PurchaseOrderNumber, dtoSalesOrderHeader.RevisionNumber, dtoSalesOrderHeader.Rowguid, dtoSalesOrderHeader.SalesOrderID, dtoSalesOrderHeader.SalesOrderNumber, dtoSalesOrderHeader.SalesPersonID, dtoSalesOrderHeader.ShipDate, dtoSalesOrderHeader.ShipMethodID, dtoSalesOrderHeader.ShipToAddressID, dtoSalesOrderHeader.Status, dtoSalesOrderHeader.SubTotal, dtoSalesOrderHeader.TaxAmt, dtoSalesOrderHeader.TerritoryID, dtoSalesOrderHeader.TotalDue);

			return model;
		}

		public virtual List<ApiSalesOrderHeaderResponseModel> MapDTOToModel(
			List<DTOSalesOrderHeader> dtos)
		{
			List<ApiSalesOrderHeaderResponseModel> response = new List<ApiSalesOrderHeaderResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9bb8d1e609d3687303ae77c046b9b0ff</Hash>
</Codenesium>*/