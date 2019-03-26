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

		Task<List<DatabaseLog>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>dd7317c000ac544abfc8b9580137bbbd</Hash>
</Codenesium>*/