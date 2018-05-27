using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public interface IDALFileMapper
	{
		void MapDTOToEF(
			int id,
			DTOFile dto,
			File efFile);

		DTOFile MapEFToDTO(
			File efFile);
	}
}

/*<Codenesium>
    <Hash>0601e296a9ca4b7859c1d9b10a815fa6</Hash>
</Codenesium>*/