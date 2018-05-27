using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALPurchaseOrderHeaderMapper
	{
		public virtual void MapDTOToEF(
			int purchaseOrderID,
			DTOPurchaseOrderHeader dto,
			PurchaseOrderHeader efPurchaseOrderHeader)
		{
			efPurchaseOrderHeader.SetProperties(
				purchaseOrderID,
				dto.EmployeeID,
				dto.Freight,
				dto.ModifiedDate,
				dto.OrderDate,
				dto.RevisionNumber,
				dto.ShipDate,
				dto.ShipMethodID,
				dto.Status,
				dto.SubTotal,
				dto.TaxAmt,
				dto.TotalDue,
				dto.VendorID);
		}

		public virtual DTOPurchaseOrderHeader MapEFToDTO(
			PurchaseOrderHeader ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPurchaseOrderHeader();

			dto.SetProperties(
				ef.PurchaseOrderID,
				ef.EmployeeID,
				ef.Freight,
				ef.ModifiedDate,
				ef.OrderDate,
				ef.RevisionNumber,
				ef.ShipDate,
				ef.ShipMethodID,
				ef.Status,
				ef.SubTotal,
				ef.TaxAmt,
				ef.TotalDue,
				ef.VendorID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>ba6fa0af642cde43d25c702b388ff501</Hash>
</Codenesium>*/