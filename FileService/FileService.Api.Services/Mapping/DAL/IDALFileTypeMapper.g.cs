using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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
    <Hash>6d7d3f99f105f720ebdd14652a90adad</Hash>
</Codenesium>*/