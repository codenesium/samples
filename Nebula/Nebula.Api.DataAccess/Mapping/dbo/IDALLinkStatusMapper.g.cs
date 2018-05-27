using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALLinkStatusMapper
	{
		void MapDTOToEF(
			int id,
			DTOLinkStatus dto,
			LinkStatus efLinkStatus);

		DTOLinkStatus MapEFToDTO(
			LinkStatus efLinkStatus);
	}
}

/*<Codenesium>
    <Hash>4abf689420a4c4d6c2dee3dffd5a3dae</Hash>
</Codenesium>*/