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
    <Hash>714b208110b4c17a4cc41e8ab6e365dd</Hash>
</Codenesium>*/