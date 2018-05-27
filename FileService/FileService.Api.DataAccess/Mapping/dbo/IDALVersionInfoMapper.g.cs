using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
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
    <Hash>15c48a63d803ed354e2c42db9d9e0b6d</Hash>
</Codenesium>*/