using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IDALVersionInfoMapper
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
    <Hash>d8164aa2918359b30b4eeb2e66f38451</Hash>
</Codenesium>*/