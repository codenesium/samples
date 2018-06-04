using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services
{
	public interface IDALVersionInfoMapper
	{
		VersionInfo MapBOToEF(
			BOVersionInfo bo);

		BOVersionInfo MapEFToBO(
			VersionInfo efVersionInfo);

		List<BOVersionInfo> MapEFToBO(
			List<VersionInfo> records);
	}
}

/*<Codenesium>
    <Hash>cc9073f2e25ac1a6786a0d4231215f14</Hash>
</Codenesium>*/