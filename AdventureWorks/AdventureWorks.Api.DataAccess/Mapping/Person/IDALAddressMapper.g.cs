using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALAddressMapper
	{
		void MapDTOToEF(
			int addressID,
			DTOAddress dto,
			Address efAddress);

		DTOAddress MapEFToDTO(
			Address efAddress);
	}
}

/*<Codenesium>
    <Hash>8cefd3d8613e4c196e92c63ba0f9d620</Hash>
</Codenesium>*/