using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public interface IDALFileMapper
	{
		File MapBOToEF(
			BOFile bo);

		BOFile MapEFToBO(
			File efFile);

		List<BOFile> MapEFToBO(
			List<File> records);
	}
}

/*<Codenesium>
    <Hash>342b28744a0ad0c808e7910bfefc34d0</Hash>
</Codenesium>*/