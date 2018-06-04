using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALDatabaseLogMapper
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
    <Hash>e942ff33a3d721617592ff8628e4324f</Hash>
</Codenesium>*/