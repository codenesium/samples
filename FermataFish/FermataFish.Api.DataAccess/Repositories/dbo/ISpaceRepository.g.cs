using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceRepository
	{
		int Create(
			string name,
			string description,
			int studioId);

		void Update(int id,
		            string name,
		            string description,
		            int studioId);

		void Delete(int id);

		Response GetById(int id);

		POCOSpace GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFSpace, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpace> GetWhereDirect(Expression<Func<EFSpace, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>04140c7c8fb8fff23724e20e62577324</Hash>
</Codenesium>*/