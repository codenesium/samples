using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesOrderHeaderMapper
	{
		public virtual void MapDTOToEF(
			int salesOrderID,
			DTOSalesOrderHeader dto,
			SalesOrderHeader efSalesOrderHeader)
		{
			efSalesOrderHeader.SetProperties(
				salesOrderID,
				dto.AccountNumber,
				dto.BillToAddressID,
				dto.Comment,
				dto.CreditCardApprovalCode,
				dto.CreditCardID,
				dto.CurrencyRateID,
				dto.CustomerID,
				dto.DueDate,
				dto.Freight,
				dto.ModifiedDate,
				dto.OnlineOrderFlag,
				dto.OrderDate,
				dto.PurchaseOrderNumber,
				dto.RevisionNumber,
				dto.Rowguid,
				dto.SalesOrderNumber,
				dto.SalesPersonID,
				dto.ShipDate,
				dto.ShipMethodID,
				dto.ShipToAddressID,
				dto.Status,
				dto.SubTotal,
				dto.TaxAmt,
				dto.TerritoryID,
				dto.TotalDue);
		}

		public virtual DTOSalesOrderHeader MapEFToDTO(
			SalesOrderHeader ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesOrderHeader();

			dto.SetProperties(
				ef.SalesOrderID,
				ef.AccountNumber,
				ef.BillToAddressID,
				ef.Comment,
				ef.CreditCardApprovalCode,
				ef.CreditCardID,
				ef.CurrencyRateID,
				ef.CustomerID,
				ef.DueDate,
				ef.Freight,
				ef.ModifiedDate,
				ef.OnlineOrderFlag,
				ef.OrderDate,
				ef.PurchaseOrderNumber,
				ef.RevisionNumber,
				ef.Rowguid,
				ef.SalesOrderNumber,
				ef.SalesPersonID,
				ef.ShipDate,
				ef.ShipMethodID,
				ef.ShipToAddressID,
				ef.Status,
				ef.SubTotal,
				ef.TaxAmt,
				ef.TerritoryID,
				ef.TotalDue);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>5dd37b6a8125d483184654a1c0823868</Hash>
</Codenesium>*/