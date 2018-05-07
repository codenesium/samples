using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		int Create(DatabaseLogModel model);

		void Update(int databaseLogID,
		            DatabaseLogModel model);

		void Delete(int databaseLogID);

		POCODatabaseLog Get(int databaseLogID);

		List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf3e51278d7661a3cb618c1ec9b3577b</Hash>
</Codenesium>*/