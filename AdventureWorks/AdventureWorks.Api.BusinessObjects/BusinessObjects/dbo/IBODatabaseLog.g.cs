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

		ApiResponse GetById(int databaseLogID);

		POCODatabaseLog GetByIdDirect(int databaseLogID);

		ApiResponse GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODatabaseLog> GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ea6f79eaa2d404de2940789341fcbf44</Hash>
</Codenesium>*/