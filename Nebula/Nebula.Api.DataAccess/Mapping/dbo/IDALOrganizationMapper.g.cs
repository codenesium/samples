using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALOrganizationMapper
	{
		void MapDTOToEF(
			int id,
			DTOOrganization dto,
			Organization efOrganization);

		DTOOrganization MapEFToDTO(
			Organization efOrganization);
	}
}

/*<Codenesium>
    <Hash>641513defed31fdd0dced26cb8fe4430</Hash>
</Codenesium>*/