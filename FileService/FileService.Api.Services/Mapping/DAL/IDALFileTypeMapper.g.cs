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
    <Hash>ff00377d44b1d3bd0918e11d7550c7c5</Hash>
</Codenesium>*/