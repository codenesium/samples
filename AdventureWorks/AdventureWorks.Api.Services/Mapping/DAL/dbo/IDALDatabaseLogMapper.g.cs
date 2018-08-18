using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDatabaseLogMapper
	{
		DatabaseLog MapBOToEF(
			BODatabaseLog bo);

		BODatabaseLog MapEFToBO(
			DatabaseLog efDatabaseLog);

		List<BODatabaseLog> MapEFToBO(
			List<DatabaseLog> records);
	}
}

/*<Codenesium>
    <Hash>1c3d7509e3cd83c4032058ea773793b2</Hash>
</Codenesium>*/