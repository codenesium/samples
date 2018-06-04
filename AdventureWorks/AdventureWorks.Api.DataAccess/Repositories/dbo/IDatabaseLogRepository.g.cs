using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		Task<DatabaseLog> Create(DatabaseLog item);

		Task Update(DatabaseLog item);

		Task Delete(int databaseLogID);

		Task<DatabaseLog> Get(int databaseLogID);

		Task<List<DatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5131317f7fe796d4ea8518827be22d88</Hash>
</Codenesium>*/