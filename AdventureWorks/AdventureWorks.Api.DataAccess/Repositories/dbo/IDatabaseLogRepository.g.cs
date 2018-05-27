using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		Task<DTODatabaseLog> Create(DTODatabaseLog dto);

		Task Update(int databaseLogID,
		            DTODatabaseLog dto);

		Task Delete(int databaseLogID);

		Task<DTODatabaseLog> Get(int databaseLogID);

		Task<List<DTODatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cfa302814070a7e7b8f726f6662bc3e4</Hash>
</Codenesium>*/