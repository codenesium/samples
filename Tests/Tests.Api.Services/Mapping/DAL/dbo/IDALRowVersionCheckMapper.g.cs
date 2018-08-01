using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALRowVersionCheckMapper
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
    <Hash>e7cef1397304e1db72a6443a33abfd5b</Hash>
</Codenesium>*/