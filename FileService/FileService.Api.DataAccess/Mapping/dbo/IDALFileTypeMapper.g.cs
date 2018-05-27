using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public interface IDALFileTypeMapper
	{
		void MapDTOToEF(
			int id,
			DTOFileType dto,
			FileType efFileType);

		DTOFileType MapEFToDTO(
			FileType efFileType);
	}
}

/*<Codenesium>
    <Hash>6ba54bfa5bb7b9798f1ec17d9f9edbf3</Hash>
</Codenesium>*/