using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALVendorMapper
	{
		public virtual Vendor MapBOToEF(
			BOVendor bo)
		{
			Vendor efVendor = new Vendor ();

			efVendor.SetProperties(
				bo.AccountNumber,
				bo.ActiveFlag,
				bo.BusinessEntityID,
				bo.CreditRating,
				bo.ModifiedDate,
				bo.Name,
				bo.PreferredVendorStatus,
				bo.PurchasingWebServiceURL);
			return efVendor;
		}

		public virtual BOVendor MapEFToBO(
			Vendor ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOVendor();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.AccountNumber,
				ef.ActiveFlag,
				ef.CreditRating,
				ef.ModifiedDate,
				ef.Name,
				ef.PreferredVendorStatus,
				ef.PurchasingWebServiceURL);
			return bo;
		}

		public virtual List<BOVendor> MapEFToBO(
			List<Vendor> records)
		{
			List<BOVendor> response = new List<BOVendor>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2e85ceef1cd253d35c408bbdc9eb7a59</Hash>
</Codenesium>*/