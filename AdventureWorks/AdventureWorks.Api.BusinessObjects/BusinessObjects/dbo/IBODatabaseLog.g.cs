using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBODatabaseLog
	{
		Task<CreateResponse<POCODatabaseLog>> Create(
			ApiDatabaseLogModel model);

		Task<ActionResponse> Update(int databaseLogID,
		                            ApiDatabaseLogModel model);

		Task<ActionResponse> Delete(int databaseLogID);

		POCODatabaseLog Get(int databaseLogID);

		List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6fe60104af459c0454d56bc6deec17bc</Hash>
</Codenesium>*/