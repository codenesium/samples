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
		Task<CreateResponse<int>> Create(
			DatabaseLogModel model);

		Task<ActionResponse> Update(int databaseLogID,
		                            DatabaseLogModel model);

		Task<ActionResponse> Delete(int databaseLogID);

		POCODatabaseLog Get(int databaseLogID);

		List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ebcaa64b78684fc3d46fc8d21dbd759b</Hash>
</Codenesium>*/