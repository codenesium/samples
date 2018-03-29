using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ILocationRepository
	{
		short Create(string name,
		             decimal costRate,
		             decimal availability,
		             DateTime modifiedDate);

		void Update(short locationID, string name,
		            decimal costRate,
		            decimal availability,
		            DateTime modifiedDate);

		void Delete(short locationID);

		void GetById(short locationID, Response response);

		void GetWhere(Expression<Func<EFLocation, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>27f5c58886ff23b2aedaf65b64ed09ba</Hash>
</Codenesium>*/