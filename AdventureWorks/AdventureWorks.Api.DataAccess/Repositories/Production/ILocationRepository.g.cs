using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ILocationRepository
	{
		short Create(
			string name,
			decimal costRate,
			decimal availability,
			DateTime modifiedDate);

		void Update(short locationID,
		            string name,
		            decimal costRate,
		            decimal availability,
		            DateTime modifiedDate);

		void Delete(short locationID);

		Response GetById(short locationID);

		POCOLocation GetByIdDirect(short locationID);

		Response GetWhere(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLocation> GetWhereDirect(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7bfe3bdd5464a52bd6e1f122e52fc310</Hash>
</Codenesium>*/