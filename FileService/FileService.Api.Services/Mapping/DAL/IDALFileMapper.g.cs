using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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
    <Hash>729b00a3af12dd5abd5f6710457f0f07</Hash>
</Codenesium>*/