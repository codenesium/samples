using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		Task<DatabaseLog> Create(DatabaseLog item);

		Task Update(DatabaseLog item);

		Task Delete(int databaseLogID);

		Task<DatabaseLog> Get(int databaseLogID);

		Task<List<DatabaseLog>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ab972877078468ad65deecc62038e609</Hash>
</Codenesium>*/