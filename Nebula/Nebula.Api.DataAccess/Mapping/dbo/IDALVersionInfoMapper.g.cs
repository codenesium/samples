using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALVersionInfoMapper
	{
		void MapDTOToEF(
			long version,
			DTOVersionInfo dto,
			VersionInfo efVersionInfo);

		DTOVersionInfo MapEFToDTO(
			VersionInfo efVersionInfo);
	}
}

/*<Codenesium>
    <Hash>d99c06c2edab000953304e8bf2a3b179</Hash>
</Codenesium>*/