using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDatabaseLogRepository
	{
		int Create(
			DateTime postTime,
			string databaseUser,
			string @event,
			string schema,
			string @object,
			string tSQL,
			string xmlEvent);

		void Update(int databaseLogID,
		            DateTime postTime,
		            string databaseUser,
		            string @event,
		            string schema,
		            string @object,
		            string tSQL,
		            string xmlEvent);

		void Delete(int databaseLogID);

		Response GetById(int databaseLogID);

		POCODatabaseLog GetByIdDirect(int databaseLogID);

		Response GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODatabaseLog> GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>be6d1f72dddf2bad3afa32e31cd2ebfd</Hash>
</Codenesium>*/