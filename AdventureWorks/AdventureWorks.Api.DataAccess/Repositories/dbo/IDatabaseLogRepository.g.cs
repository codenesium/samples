using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		Task<POCODatabaseLog> Create(ApiDatabaseLogModel model);

		Task Update(int databaseLogID,
		            ApiDatabaseLogModel model);

		Task Delete(int databaseLogID);

		Task<POCODatabaseLog> Get(int databaseLogID);

		Task<List<POCODatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cfb4924752734e4b6fd7b313895536ce</Hash>
</Codenesium>*/