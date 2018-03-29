using System;
using System.Linq.Expressions;
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

		void GetById(int databaseLogID, Response response);

		void GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d80313db75e35a1b43456be3a519520b</Hash>
</Codenesium>*/