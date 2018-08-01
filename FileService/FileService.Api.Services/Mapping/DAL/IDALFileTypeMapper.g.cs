using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public interface IDALFileTypeMapper
	{
		FileType MapBOToEF(
			BOFileType bo);

		BOFileType MapEFToBO(
			FileType efFileType);

		List<BOFileType> MapEFToBO(
			List<FileType> records);
	}
}

/*<Codenesium>
    <Hash>84ccf2b175e54bf41cfa89756034d440</Hash>
</Codenesium>*/