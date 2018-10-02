using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALSysdiagramMapper
	{
		Sysdiagram MapBOToEF(
			BOSysdiagram bo);

		BOSysdiagram MapEFToBO(
			Sysdiagram efSysdiagram);

		List<BOSysdiagram> MapEFToBO(
			List<Sysdiagram> records);
	}
}

/*<Codenesium>
    <Hash>587359ee6e7dbef2ff643869cd2ce0cc</Hash>
</Codenesium>*/