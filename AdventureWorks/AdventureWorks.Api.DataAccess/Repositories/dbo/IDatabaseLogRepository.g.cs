using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IDatabaseLogRepository
	{
		Task<DatabaseLog> Create(DatabaseLog item);

		Task Update(DatabaseLog item);

		Task Delete(int databaseLogID);

		Task<DatabaseLog> Get(int databaseLogID);

		Task<List<DatabaseLog>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c9f21504553c5abd8642317c21961072</Hash>
</Codenesium>*/