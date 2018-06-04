using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALBusinessEntityAddressMapper
	{
		public virtual BusinessEntityAddress MapBOToEF(
			BOBusinessEntityAddress bo)
		{
			BusinessEntityAddress efBusinessEntityAddress = new BusinessEntityAddress ();

			efBusinessEntityAddress.SetProperties(
				bo.AddressID,
				bo.AddressTypeID,
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.Rowguid);
			return efBusinessEntityAddress;
		}

		public virtual BOBusinessEntityAddress MapEFToBO(
			BusinessEntityAddress ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOBusinessEntityAddress();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.AddressID,
				ef.AddressTypeID,
				ef.ModifiedDate,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOBusinessEntityAddress> MapEFToBO(
			List<BusinessEntityAddress> records)
		{
			List<BOBusinessEntityAddress> response = new List<BOBusinessEntityAddress>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4c2c1b2b41f4ab3678f6c562dcef4211</Hash>
</Codenesium>*/