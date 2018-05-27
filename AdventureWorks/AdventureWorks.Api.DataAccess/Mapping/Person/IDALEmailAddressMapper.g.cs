using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALEmailAddressMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOEmailAddress dto,
			EmailAddress efEmailAddress);

		DTOEmailAddress MapEFToDTO(
			EmailAddress efEmailAddress);
	}
}

/*<Codenesium>
    <Hash>6e8fb0c592db251153b1585276e449e5</Hash>
</Codenesium>*/