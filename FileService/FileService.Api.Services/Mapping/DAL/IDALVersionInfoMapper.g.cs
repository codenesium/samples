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
    <Hash>ed9d0a48d21c787125da187fd30531a7</Hash>
</Codenesium>*/