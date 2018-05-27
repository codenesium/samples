using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALBusinessEntityAddressMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOBusinessEntityAddress dto,
			BusinessEntityAddress efBusinessEntityAddress);

		DTOBusinessEntityAddress MapEFToDTO(
			BusinessEntityAddress efBusinessEntityAddress);
	}
}

/*<Codenesium>
    <Hash>d81951bfb0ef1de9e809d1c21b4b43ba</Hash>
</Codenesium>*/