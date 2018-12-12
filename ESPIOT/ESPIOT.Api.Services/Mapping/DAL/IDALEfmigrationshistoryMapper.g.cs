using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public partial interface IDALEfmigrationshistoryMapper
	{
		Efmigrationshistory MapBOToEF(
			BOEfmigrationshistory bo);

		BOEfmigrationshistory MapEFToBO(
			Efmigrationshistory efEfmigrationshistory);

		List<BOEfmigrationshistory> MapEFToBO(
			List<Efmigrationshistory> records);
	}
}

/*<Codenesium>
    <Hash>d329107a49bf91a61170cc15ca3d8f03</Hash>
</Codenesium>*/