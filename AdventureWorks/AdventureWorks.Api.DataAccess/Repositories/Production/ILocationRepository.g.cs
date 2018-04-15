using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ILocationRepository
	{
		short Create(LocationModel model);

		void Update(short locationID,
		            LocationModel model);

		void Delete(short locationID);

		ApiResponse GetById(short locationID);

		POCOLocation GetByIdDirect(short locationID);

		ApiResponse GetWhere(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLocation> GetWhereDirect(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>62326acd186a796ca9d131209da823f9</Hash>
</Codenesium>*/