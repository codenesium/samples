using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALRowVersionCheckMapper
	{
		RowVersionCheck MapBOToEF(
			BORowVersionCheck bo);

		BORowVersionCheck MapEFToBO(
			RowVersionCheck efRowVersionCheck);

		List<BORowVersionCheck> MapEFToBO(
			List<RowVersionCheck> records);
	}
}

/*<Codenesium>
    <Hash>ebc1164014eb793c593279dcb0603f4f</Hash>
</Codenesium>*/