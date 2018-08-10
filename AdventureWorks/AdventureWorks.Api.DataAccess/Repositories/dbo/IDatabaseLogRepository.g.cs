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
    <Hash>f070fc9e224720338400a4321c212706</Hash>
</Codenesium>*/