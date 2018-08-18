using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IDALFileMapper
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
    <Hash>56ab472cb2838d58b778daaafaff1e4b</Hash>
</Codenesium>*/