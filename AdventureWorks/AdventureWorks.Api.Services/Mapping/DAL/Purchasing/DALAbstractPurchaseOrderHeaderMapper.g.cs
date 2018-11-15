using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractPurchaseOrderHeaderMapper
	{
		public virtual PurchaseOrderHeader MapBOToEF(
			BOPurchaseOrderHeader bo)
		{
			PurchaseOrderHeader efPurchaseOrderHeader = new PurchaseOrderHeader();
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
    <Hash>e5724a53ddbd5ded15714a738428d77b</Hash>
</Codenesium>*/