using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractBusinessEntityAddressMapper
	{
		public virtual BusinessEntityAddress MapBOToEF(
			BOBusinessEntityAddress bo)
		{
			BusinessEntityAddress efBusinessEntityAddress = new BusinessEntityAddress();
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
    <Hash>abad0886b534922e26560f333a7fb0a9</Hash>
</Codenesium>*/