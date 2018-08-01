using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>8a0480bad32797c05bfe3d50444d153d</Hash>
</Codenesium>*/