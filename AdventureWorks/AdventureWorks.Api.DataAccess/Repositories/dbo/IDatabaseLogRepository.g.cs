using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		POCODatabaseLog Create(ApiDatabaseLogModel model);

		void Update(int databaseLogID,
		            ApiDatabaseLogModel model);

		void Delete(int databaseLogID);

		POCODatabaseLog Get(int databaseLogID);

		List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>158e1a98909be9df850b4502bc6dffd6</Hash>
</Codenesium>*/