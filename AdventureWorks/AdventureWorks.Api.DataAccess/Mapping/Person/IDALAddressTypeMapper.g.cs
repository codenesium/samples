using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALAddressTypeMapper
	{
		void MapDTOToEF(
			int addressTypeID,
			DTOAddressType dto,
			AddressType efAddressType);

		DTOAddressType MapEFToDTO(
			AddressType efAddressType);
	}
}

/*<Codenesium>
    <Hash>7f2a5929eb450bf9e72465b0b2696cd6</Hash>
</Codenesium>*/