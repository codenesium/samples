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
    <Hash>302a2910ed6caeb2c7d0a3a45ae54821</Hash>
</Codenesium>*/