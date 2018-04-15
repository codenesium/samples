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

		ApiResponse GetById(int databaseLogID);

		POCODatabaseLog GetByIdDirect(int databaseLogID);

		ApiResponse GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODatabaseLog> GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a2490ab81976cb3c06f4d002e96e3385</Hash>
</Codenesium>*/