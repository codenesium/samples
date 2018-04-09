using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		int Create(DateTime postTime,
		           string databaseUser,
		           string @event,
		           string schema,
		           string @object,
		           string tSQL,
		           string xmlEvent);

		void Update(int databaseLogID, DateTime postTime,
		            string databaseUser,
		            string @event,
		            string schema,
		            string @object,
		            string tSQL,
		            string xmlEvent);

		void Delete(int databaseLogID);

		Response GetById(int databaseLogID);

		POCODatabaseLog GetByIdDirect(int databaseLogID);

		Response GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCODatabaseLog> GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>afe7abd49ee013e2ac47d7b5b99ca668</Hash>
</Codenesium>*/