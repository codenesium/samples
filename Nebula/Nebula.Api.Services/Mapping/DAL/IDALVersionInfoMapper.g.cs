using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
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
    <Hash>d9734abc893fe6d88dbfaa5dc3710a8c</Hash>
</Codenesium>*/