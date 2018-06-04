using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPurchaseOrderHeaderMapper
	{
		public virtual PurchaseOrderHeader MapBOToEF(
			BOPurchaseOrderHeader bo)
		{
			PurchaseOrderHeader efPurchaseOrderHeader = new PurchaseOrderHeader ();

			efPurchaseOrderHeader.SetProperties(
				bo.EmployeeID,
				bo.Freight,
				bo.ModifiedDate,
				bo.OrderDate,
				bo.PurchaseOrderID,
				bo.RevisionNumber,
				bo.ShipDate,
				bo.ShipMethodID,
				bo.Status,
				bo.SubTotal,
				bo.TaxAmt,
				bo.TotalDue,
				bo.VendorID);
			return efPurchaseOrderHeader;
		}

		public virtual BOPurchaseOrderHeader MapEFToBO(
			PurchaseOrderHeader ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPurchaseOrderHeader();

			bo.SetProperties(
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
			return bo;
		}

		public virtual List<BOPurchaseOrderHeader> MapEFToBO(
			List<PurchaseOrderHeader> records)
		{
			List<BOPurchaseOrderHeader> response = new List<BOPurchaseOrderHeader>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3c8af2c7bda89c9bb7ce2c8ddddbfbae</Hash>
</Codenesium>*/