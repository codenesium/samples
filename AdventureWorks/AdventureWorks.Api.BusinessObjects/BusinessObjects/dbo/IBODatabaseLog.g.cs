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

		Task<POCODatabaseLog> Get(int databaseLogID);

		Task<List<POCODatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>101f097c9c33bcc4be91fe8136f59166</Hash>
</Codenesium>*/