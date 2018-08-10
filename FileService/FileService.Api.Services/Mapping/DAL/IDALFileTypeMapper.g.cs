using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IDALFileTypeMapper
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
    <Hash>70da9096ce0c6a48f5eda1b8f9fd3387</Hash>
</Codenesium>*/