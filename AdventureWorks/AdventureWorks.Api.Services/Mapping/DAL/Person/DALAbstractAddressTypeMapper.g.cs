using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractAddressTypeMapper
	{
		public virtual AddressType MapBOToEF(
			BOAddressType bo)
		{
			AddressType efAddressType = new AddressType();
			efAddressType.SetProperties(
				bo.AddressTypeID,
				bo.ModifiedDate,
				bo.Name,
				bo.Rowguid);
			return efAddressType;
		}

		public virtual BOAddressType MapEFToBO(
			AddressType ef)
		{
			var bo = new BOAddressType();

			bo.SetProperties(
				ef.AddressTypeID,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOAddressType> MapEFToBO(
			List<AddressType> records)
		{
			List<BOAddressType> response = new List<BOAddressType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>59981837e3badf5de76846c9ce1deb8d</Hash>
</Codenesium>*/