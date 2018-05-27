using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALLinkLogMapper
	{
		void MapDTOToEF(
			int id,
			DTOLinkLog dto,
			LinkLog efLinkLog);

		DTOLinkLog MapEFToDTO(
			LinkLog efLinkLog);
	}
}

/*<Codenesium>
    <Hash>377ba5d59663f764679562db8ca41feb</Hash>
</Codenesium>*/