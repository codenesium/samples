using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractVendorMapper
	{
		public virtual Vendor MapBOToEF(
			BOVendor bo)
		{
			Vendor efVendor = new Vendor();
			efVendor.SetProperties(
				bo.AccountNumber,
				bo.ActiveFlag,
				bo.BusinessEntityID,
				bo.CreditRating,
				bo.ModifiedDate,
				bo.Name,
				bo.PreferredVendorStatu,
				bo.PurchasingWebServiceURL);
			return efVendor;
		}

		public virtual BOVendor MapEFToBO(
			Vendor ef)
		{
			var bo = new BOVendor();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.AccountNumber,
				ef.ActiveFlag,
				ef.CreditRating,
				ef.ModifiedDate,
				ef.Name,
				ef.PreferredVendorStatu,
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
    <Hash>3031ce451379f11e1e7cb8156fcc5e1a</Hash>
</Codenesium>*/